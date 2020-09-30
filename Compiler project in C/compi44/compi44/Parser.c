#include "Token.h"
#include "Parser.h"
#include "SymbolTable.h" 
Token *token = NULL;
FILE *out_parser;
Table *root_table = NULL, *current_table = NULL;
int match(eTOKENS expected_kind)
{
	token = next_token();

	// Token was matched.
	if (token->kind == expected_kind)
		return 1;

	// Print error message.
	fprintf(out_parser, "Expected: token '%s' at line %d,\nActual token: '%s', lexeme: '%s'\n", getEnumTokenName(expected_kind),
		token->lineNumber,
		getEnumTokenName(token->kind),
		token->lexeme);

	// Token was not matched.
	return 0;
}

void parse_PROGRAM()
{
	fprintf(out_parser, "Rule(PROGRAM -> BLOCK)\n");
	eTOKENS kind;
	Token* nt = next_token();
	kind = nt->kind;
	if (kind == TOKEN_EOF)
	{
		nt = back_token();
		return;
	}
	nt = back_token();
	parse_BLOCK();
}

void parse_BLOCK()
{
	parse_BB(); // new
	fprintf(out_parser, "Rule(BLOCK – block DECLARATIONS begin STATEMENTS end)\n");
	match(TOKEN_KEYWORD_BLOCK);
	parse_DECLARATIONS();
	match(TOKEN_KEYWORD_BEGIN);
	parse_STATEMENTS();
	match(TOKEN_KEYWORD_END);
	parse_FB();
}

void parse_DECLARATIONS()
{
	fprintf(out_parser, "Rule(DECLARATION  DECLARATIONS_TAG)\n");
	parse_DECLARATION();
	parse_DECLARATIONS_TAG();
}

void parse_DECLARATION()
{
	eTOKENS kind;
	Token* nt = next_token();
	kind = nt->kind;
	switch (kind)
	{
	case TOKEN_ID:
	{
		fprintf(out_parser, "Rule(DECLARATION->id VAR_DECLARATION)\n");
		nt = back_token();
		parse_VAR_DECLARATION();
		break;
	}
	case TOKEN_KEYWORD_TYPE:
	{
		fprintf(out_parser, "Rule(DECLARATION->type TYPE_DECLARATION)\n");
		nt = back_token();
		parse_TYPE_DECLARATION();
		break;
	}
	default:
		fprintf(out_parser, "ERROR: excpected tokens: TOKEN_ID or TOKEN_KEYWORD_TYPE, current token: %s, line: %d \n",getEnumTokenName(nt->kind), nt->lineNumber);
		break;
	}
}
void parse_DECLARATIONS_TAG()
{
	eTOKENS kind;
	Token* nt = next_token();
	kind = nt->kind;
	switch (kind)
	{
	case TOKEN_SEP_SEMMICOLON: // first of DECLARATIONS_TAG
	{
		fprintf(out_parser, "Rule(DECLARATIONS_TAG->DECLARATIONS)\n");
		parse_DECLARATIONS();
		break;
	}
	case TOKEN_KEYWORD_BEGIN: // follow  of DECLARATIONS_TAG
	{
		fprintf(out_parser, "Rule(DECLARATIONS_TAG->epsilon)\n");
		nt = back_token();
		break;
	}
	default:
		fprintf(out_parser, "ERROR: excpected token: %s , current token: %s, line: %d \n", getEnumTokenName(TOKEN_SEP_SEMMICOLON), getEnumTokenName(nt->kind), nt->lineNumber);
		while (nt->kind != TOKEN_KEYWORD_BEGIN && nt->kind !=  TOKEN_EOF) {
			nt = next_token();
		}
		nt = back_token();
		break;
	}
}




void parse_VAR_DECLARATION()
{
	fprintf(out_parser, "Rule(id: VAR_DECLARATION_TAG)\n");
	Token *tk = next_token();
	TableEntry *id_table_entry = insert(current_table, tk->lexeme);
	tk = back_token();
	match(TOKEN_ID);
	match(TOKEN_SEP_COLON);
	Type _type;
	Variable _var;
	parse_VAR_DECLARATION_TAG(&_type,&_var);
}

void parse_VAR_DECLARATION_TAG()
{
	eTOKENS kind;
	Token* nt = next_token();
	kind = nt->kind;
	switch (kind)
	{
	case TOKEN_KEYWORD_INTEGER:
	{
		fprintf(out_parser, "Rule(parse_VAR_DECLARATION_TAG->SIMPLE_TYPE)\n");
		nt = back_token();
		parse_SIMPLE_TYPE();
		break;
	}
	case TOKEN_KEYWORD_REAL:
	{
		fprintf(out_parser, "Rule(parse_VAR_DECLARATION_TAG->SIMPLE_TYPE)\n");
		nt = back_token();
		parse_SIMPLE_TYPE();
		break;
	}
	case TOKEN_KEYWORD_ARRAY:
	{
		fprintf(out_parser, "Rule(parse_VAR_DECLARATION_TAG->array)\n");
		match(TOKEN_SEP_SQR_BRACKET_RIGHT);
		parse_SIZE();
		match(TOKEN_SEP_SQR_BRACKET_LEFT);
		match(TOKEN_KEYWORD_OF);
		parse_SIMPLE_TYPE();
		break;
	}
	case TOKEN_TYPE_NAME:
	{
		fprintf(out_parser, "Rule(parse_VAR_DECLARATION_TAG->type_name)\n");
		break;
	}
	default:
		fprintf(out_parser, "ERROR: excpected to derive VAR_DECLARATION_TAG and its firsts tokens,but current token: %s, line: %d \n", getEnumTokenName(nt->kind), nt->lineNumber);
		while (nt->kind != TOKEN_KEYWORD_BEGIN && nt->kind != TOKEN_SEP_SEMMICOLON && nt->kind != TOKEN_SEP_CURLY_BRACKET_LEFT && nt->kind != TOKEN_EOF) {
			nt = next_token();
		}
		nt = back_token();
		break;
	}
}

void parse_SIMPLE_TYPE()
{
	eTOKENS kind;
	Token* nt = next_token();
	kind = nt->kind;
	switch (kind)
	{
	case TOKEN_KEYWORD_INTEGER:
	{
		fprintf(out_parser, "Rule(SIMPLE_TYPE->integer)\n");
		break;
	}
	case TOKEN_KEYWORD_REAL:
	{
		fprintf(out_parser, "Rule(SIMPLE_TYPE->real)\n");
		break;
	}
	default:
		fprintf(out_parser, "ERROR: excpected tokens: TOKEN_KEYWORD_INTEGER or  TOKEN_KEYWORD_REAL, current token: %s, line: %d \n", getEnumTokenName(nt->kind), nt->lineNumber);
		while (nt->kind != TOKEN_KEYWORD_BEGIN && nt->kind != TOKEN_SEP_SEMMICOLON && nt->kind != TOKEN_SEP_CURLY_BRACKET_LEFT && nt->kind != TOKEN_EOF) {
			nt = next_token();
		}
		nt = back_token();
		break;
	}
}


void parse_SIZE()
{
	fprintf(out_parser, "Rule(SIZE->int_num)\n");
	match(TOKEN_INTEGER);
}


void parse_TYPE_DECLARATION()
{
	fprintf(out_parser, "Rule(TYPE_DECLARATION->type type_name is TYPE_INDICATOR)\n");
	match(TOKEN_KEYWORD_TYPE);
	match(TOKEN_TYPE_NAME);
	match(TOKEN_KEYWORD_IS);
	parse_TYPE_INDICATOR();
}



void parse_TYPE_INDICATOR()
{
	eTOKENS kind;
	Token* nt = next_token();
	kind = nt->kind;
	switch (kind)
	{
	case TOKEN_KEYWORD_ENUM:
	{
		fprintf(out_parser, "Rule(TYPE_INDICATOR->enum)\n");
		nt = back_token();
		parse_ENUM_TYPE();
		break;
	}
	case TOKEN_KEYWORD_STRUCT:
	{
		fprintf(out_parser, "Rule(TYPE_INDICATOR->struct)\n");
		nt = back_token();
		parse_STRUCTURE_TYPE();
		break;
	}
	default:
		fprintf(out_parser, "ERROR: excpected tokens: TOKEN_KEYWORD_ENUM or TOKEN_KEYWORD_STRUCT, current token: %s, line: %d \n", getEnumTokenName(nt->kind), nt->lineNumber);
		while (nt->kind != TOKEN_KEYWORD_BEGIN && nt->kind != TOKEN_SEP_SEMMICOLON  && nt->kind != TOKEN_EOF) {
			nt = next_token();
		}
		nt = back_token();
		break;
	}
}

void parse_ENUM_TYPE()
{
	fprintf(out_parser, "Rule(ENUM_TYPE->enum { ID_LIST })\n");
	match(TOKEN_KEYWORD_ENUM);
	match(TOKEN_SEP_CURLY_BRACKET_RIGHT);
	parse_ID_LIST();
	match(TOKEN_SEP_CURLY_BRACKET_LEFT);
}
void parse_ID_LIST()
{
	fprintf(out_parser, "Rule(ID_LIST->id ID_LIST_TAG)\n");
	match(TOKEN_ID);
	parse_ID_LIST_TAG();
}

void parse_ID_LIST_TAG()
{
	eTOKENS kind;
	Token* nt = next_token();
	kind = nt->kind;
	switch (kind)
	{
	case TOKEN_SEP_COMMA:
	{
		fprintf(out_parser, "Rule(ID_LIST_TAG->comma)\n");
		parse_ID_LIST();
		break;
	}
	case TOKEN_SEP_CURLY_BRACKET_LEFT:
	{
		fprintf(out_parser, "Rule(ID_LIST_TAG->epsilon)\n");
		nt = back_token();
		break;
	}
	default:
		fprintf(out_parser, "ERROR: excpected tokens: TOKEN_SEP_COMMA or TOKEN_SEP_CURLY_BRACKET_LEFT, current token: %s, line: %d \n", getEnumTokenName(nt->kind), nt->lineNumber);
		while (nt->kind != TOKEN_SEP_CURLY_BRACKET_LEFT && nt->kind != TOKEN_EOF) {
			nt = next_token();
		}
		nt = back_token();
		break;
	}
}

void parse_STRUCTURE_TYPE()
{
	fprintf(out_parser, "Rule(STRUCTURE_TYPE->struct { FIELDS })\n");
	match(TOKEN_KEYWORD_STRUCT);
	match(TOKEN_SEP_CURLY_BRACKET_RIGHT);
	parse_FIELDS();
	match(TOKEN_SEP_CURLY_BRACKET_LEFT);
}

void parse_FIELDS()
{
	fprintf(out_parser, "Rule(STRUCTURE_TYPE-> FIELD FIELDS_TAG)\n");
	parse_FIELD();
	parse_FIELDS_TAG();
}

void parse_FIELD()
{
	fprintf(out_parser, "Rule(FIELD -> VAR_DECLARATION)\n");
	parse_VAR_DECLARATION();
}

void parse_FIELDS_TAG()
{
	eTOKENS kind;
	Token* nt = next_token();
	kind = nt->kind;
	switch (kind)
	{
	case TOKEN_SEP_SEMMICOLON:
	{
		fprintf(out_parser, "Rule(FIELDS_TAG->SEMICOLON)\n");
		//nt = back_token();
		parse_FIELD();
		parse_FIELDS_TAG();
		break;
	}
	case TOKEN_SEP_CURLY_BRACKET_LEFT:
	{
		fprintf(out_parser, "Rule(FIELDS_TAG->CURLY_BRACKET_RIGHT)\n");
		nt = back_token();
		break;
	}
	default:
		fprintf(out_parser, "ERROR: excpected tokens: TOKEN_SEP_SEMMICOLON or TOKEN_SEP_CURLY_BRACKET_LEFT, current token: %s, line: %d \n", getEnumTokenName(nt->kind), nt->lineNumber);
		while (nt->kind != TOKEN_SEP_CURLY_BRACKET_LEFT && nt->kind != TOKEN_EOF) {
			nt = next_token();
		}
		nt = back_token();
		break;
	}
}



void parse_STATEMENTS()
{
	fprintf(out_parser, "Rule(STATEMENTS -> STATEMENT STATEMENTS_TAG)\n");
	parse_STATEMENT();
	parse_STATEMENTS_TAG();
}
void parse_STATEMENT()
{
	eTOKENS kind;
	Token* nt = next_token();
	kind = nt->kind;
	switch (kind)
	{
	case TOKEN_ID:
	{
		fprintf(out_parser, "Rule(STATEMENT->VAR_ELEMENT = EXPRESSION)\n");
		nt = back_token();
		parse_VAR_ELEMENT();
		match(TOKEN_OP_EQUAL);
		parse_EXPRESSION();
		break;
	}
	case TOKEN_KEYWORD_BREAK:
	{
		fprintf(out_parser, "Rule(STATEMENT->BREAK)\n");
		break;
	}

	case TOKEN_KEYWORD_BLOCK:
	{
		fprintf(out_parser, "Rule(STATEMENT->BLOCK)\n");
		nt = back_token();
		parse_BLOCK();
		break;
	}
	case TOKEN_KEYWORD_SWITCH:
	{
		fprintf(out_parser, "Rule(STATEMENT->SWITCH)\n");
		match(TOKEN_SEP_PARENTHESES_RIGHT);
		parse_KEY();
		match(TOKEN_SEP_PARENTHESES_LEFT);
		match(TOKEN_SEP_CURLY_BRACKET_RIGHT);
		parse_CASE_LIST();
		match(TOKEN_SEP_SEMMICOLON);
		match(TOKEN_KEYWORD_DEFAULT);
		match(TOKEN_SEP_COLON);
		parse_STATEMENTS();
		match(TOKEN_SEP_CURLY_BRACKET_LEFT);
		break;
	}
	
	default:
		fprintf(out_parser, "ERROR: excpected tokens: TOKEN_ID or  TOKEN_KEYWORD_BREAK OR TOKEN_KEYWORD_BLOCK OR TOKEN_KEYWORD_SWITCH, current token: %s, line: %d \n", getEnumTokenName(nt->kind), nt->lineNumber);
		while (nt->kind != TOKEN_SEP_CURLY_BRACKET_LEFT && nt->kind != TOKEN_SEP_SEMMICOLON && nt->kind != TOKEN_KEYWORD_END && nt->kind != TOKEN_EOF) {
			nt = next_token();
		}
		nt = back_token();
		break;
	}
}


void parse_STATEMENTS_TAG()
{
	eTOKENS kind;
	Token* nt = next_token();
	kind = nt->kind;
	switch (kind)
	{
	case TOKEN_SEP_SEMMICOLON:
	{
		/*Token* nt = next_token();
		if (nt->kind == TOKEN_KEYWORD_END) {
			fprintf(out_parser, "Last statement..\n");
			nt = back_token();
			break;
		}
		nt = back_token();*/
		fprintf(out_parser, "Rule(STATEMENTS_TAG->; STATEMENT STATEMENTS_TAG)\n");
		parse_STATEMENT();
		parse_STATEMENTS_TAG();
		break;
	}
	case TOKEN_KEYWORD_END:
	{
		fprintf(out_parser, "Rule(STATEMENTS_TAG->epsilon)\n");
		nt = back_token();
		break;
	}
	case TOKEN_SEP_CURLY_BRACKET_LEFT:
	{
		fprintf(out_parser, "Rule(STATEMENTS_TAG->epsilon)\n");
		nt = back_token();
		break;
	}
	default:
		fprintf(out_parser, "ERROR: excpected tokens: TOKEN_SEP_SEMMICOLON or  TOKEN_KEYWORD_END OR TOKEN_SEP_CURLY_BRACKET_LEFT, current token: %s, line: %d \n", getEnumTokenName(nt->kind), nt->lineNumber);
		while (nt->kind != TOKEN_SEP_CURLY_BRACKET_LEFT &&  nt->kind != TOKEN_KEYWORD_END && nt->kind != TOKEN_EOF) {
			nt = next_token();
		}
		nt = back_token();
		break;
	}
}

void parse_VAR_ELEMENT()
{
	eTOKENS kind;
	Token* nt = next_token();
	kind = nt->kind;
	
	switch (kind)
	{
	case TOKEN_ID:
	{
		Token* look_up_token = next_token();
		eTOKENS look_up_kind = look_up_token->kind;
		if (look_up_kind == TOKEN_DOT) {
			fprintf(out_parser, "Rule(VAR_ELEMENT->FIELD_ACCESS)\n");
			nt = back_token();
			nt = back_token();
			parse_FIELD_ACCESS();
		}
		else
		{
			fprintf(out_parser, "Rule(VAR_ELEMENT->id VAR_ELEMENT_TAG)\n");
			nt = back_token();
			parse_VAR_ELEMENT_TAG();
		}
	}
	default:
		fprintf(out_parser, "ERROR: excpected token: TOKEN_ID, current token: %s, line: %d \n", getEnumTokenName(nt->kind), nt->lineNumber);
		while (nt->kind != TOKEN_OP_EQUAL && nt->kind != TOKEN_SEP_PARENTHESES_LEFT && nt->kind != TOKEN_SEP_SEMMICOLON && nt->kind != TOKEN_SEP_CURLY_BRACKET_LEFT && nt->kind != TOKEN_SEP_SQR_BRACKET_LEFT && nt->kind != TOKEN_KEYWORD_END && nt->kind != TOKEN_EOF) {
			nt = next_token();
		}
		nt = back_token();
		break;
	}
}

void parse_VAR_ELEMENT_TAG()
{
	eTOKENS kind;
	Token* nt = next_token();
	kind = nt->kind;
	switch (kind)
	{
	case TOKEN_SEP_SQR_BRACKET_RIGHT:
	{
		fprintf(out_parser, "Rule(VAR_ELEMENT_TAG-> [EXPRESSION] )\n");
		parse_EXPRESSION();
		match(TOKEN_SEP_SQR_BRACKET_LEFT);
		break;
	}
	case TOKEN_OP_EQUAL:
	{
		fprintf(out_parser, "Rule(VAR_ELEMENT_TAG-> epsilon )\n");
		nt = back_token();
		break;
	}
	case TOKEN_SEP_PARENTHESES_LEFT:
	{
		fprintf(out_parser, "Rule(VAR_ELEMENT_TAG-> epsilon )\n");
		nt = back_token();
		break;
	}
	case TOKEN_AR_OP:
	{
		fprintf(out_parser, "Rule(VAR_ELEMENT_TAG-> epsilon )\n");
		nt = back_token();
		break;
	}
	case TOKEN_SEP_SQR_BRACKET_LEFT: // added just recently, i am not sure about that...
	{
		fprintf(out_parser, "Rule(VAR_ELEMENT_TAG-> epsilon )\n");
		nt = back_token();
		break;
	}
	case TOKEN_SEP_SEMMICOLON: // MAYBE??
	{
		fprintf(out_parser, "Rule(VAR_ELEMENT_TAG-> epsilon )\n");
		nt = back_token();
		break;
	}
	case TOKEN_SEP_CURLY_BRACKET_LEFT:
	{
		fprintf(out_parser, "Rule(VAR_ELEMENT_TAG-> epsilon )\n");
		nt = back_token();
		break;
	}
	case TOKEN_KEYWORD_END: // recently added...
	{
		fprintf(out_parser, "Rule(VAR_ELEMENT_TAG-> epsilon )\n");
		nt = back_token();
		break;
	}
	default:
		fprintf(out_parser, "ERROR: excpected tokens: TOKEN_SEP_SQR_BRACKET_RIGHT,TOKEN_OP_EQUAL,TOKEN_SEP_PARENTHESES_LEFT,TOKEN_AR_OP, current token: %s, line: %d \n", getEnumTokenName(nt->kind), nt->lineNumber);
		while (nt->kind != TOKEN_OP_EQUAL && nt->kind != TOKEN_SEP_PARENTHESES_LEFT && nt->kind != TOKEN_SEP_SEMMICOLON && nt->kind != TOKEN_SEP_CURLY_BRACKET_LEFT && nt->kind != TOKEN_SEP_SQR_BRACKET_LEFT && nt->kind != TOKEN_KEYWORD_END && nt->kind != TOKEN_EOF) {
			nt = next_token();
		}
		nt = back_token();
		break;
	}

}

void parse_EXPRESSION()
{
	fprintf(out_parser, "Rule(EXPRESSION->SIMPLE_EXPRESSION EXPRESSION_TAG)\n");
	parse_SIMPLE_EXPRESSION();
	parse_EXPRESSION_TAG();
}

void parse_SIMPLE_EXPRESSION()
{
	eTOKENS kind;
	Token* nt = next_token();
	kind = nt->kind;
	switch (kind)
	{
	case TOKEN_INTEGER:
	{
		fprintf(out_parser, "Rule(SIMPLE_EXPRESSION->int_num)\n");
		break;
	}
	case TOKEN_REAL:
	{
		fprintf(out_parser, "Rule(SIMPLE_EXPRESSION->int_real)\n");
		break;
	}
	case TOKEN_ID:
	{
		fprintf(out_parser, "Rule(SIMPLE_EXPRESSION-> VAR_ELEMENT)\n");
		nt = back_token();
		parse_VAR_ELEMENT();
		break;
	}
	default:
		fprintf(out_parser, "ERROR: excpected tokens: TOKEN_INTEGER,TOKEN_REAL,TOKEN_ID, current token: %s, line: %d \n", getEnumTokenName(nt->kind), nt->lineNumber);
		while (nt->kind != TOKEN_SEP_SEMMICOLON && nt->kind != TOKEN_SEP_CURLY_BRACKET_LEFT && nt->kind != TOKEN_SEP_SQR_BRACKET_LEFT && nt->kind != TOKEN_KEYWORD_END && nt->kind != TOKEN_AR_OP && nt->kind != TOKEN_EOF) {
			nt = next_token();
		}
		nt = back_token();
		break;
	}
}

void parse_EXPRESSION_TAG()
{
	eTOKENS kind;
	Token* nt = next_token();
	kind = nt->kind;
	switch (kind)
	{
	case TOKEN_AR_OP:
	{
		fprintf(out_parser, "Rule(EXPRESSION_TAG->ar_op EXPRESSION)\n");
		parse_EXPRESSION();
		break;
	}
	case TOKEN_SEP_SQR_BRACKET_LEFT:
	{
		fprintf(out_parser, "Rule(EXPRESSION_TAG->epsilon)\n");
		nt = back_token();
		break;
	}
	case TOKEN_SEP_SEMMICOLON:
	{
		fprintf(out_parser, "Rule(EXPRESSION_TAG->epsilon)\n");
		nt = back_token();
		break;
	}
	case TOKEN_KEYWORD_END:
	{
		fprintf(out_parser, "Rule(EXPRESSION_TAG->epsilon)\n");
		nt = back_token();
		break;
	}
	case TOKEN_SEP_CURLY_BRACKET_LEFT:
	{
		fprintf(out_parser, "Rule(EXPRESSION_TAG->epsilon)\n");
		nt = back_token();
		break;
	}
	default:
		fprintf(out_parser, "ERROR: excpected tokens: TOKEN_AR_OP,TOKEN_SEP_SQR_BRACKET_LEFT,TOKEN_SEP_SEMMICOLON, current token: %s, line: %d \n", getEnumTokenName(nt->kind), nt->lineNumber);
		while (nt->kind != TOKEN_SEP_SEMMICOLON && nt->kind != TOKEN_SEP_CURLY_BRACKET_LEFT && nt->kind != TOKEN_SEP_SQR_BRACKET_LEFT && nt->kind != TOKEN_KEYWORD_END  && nt->kind != TOKEN_EOF) {
			nt = next_token();
		}
		nt = back_token();
		break;
	}
}

void parse_FIELD_ACCESS()
{
	fprintf(out_parser, "Rule(FIELD_ACCESS -> id. FIELD_ACCESS_TAG)\n");
	match(TOKEN_ID);
	match(TOKEN_DOT);
	parse_FIELD_ACCESS_TAG();
}


void parse_FIELD_ACCESS_TAG()
{
	eTOKENS kind;
	match(TOKEN_ID);
	Token* nt = next_token();

	if (nt->kind == TOKEN_DOT) {
		fprintf(out_parser, "Rule(FIELD_ACCESS_TAG -> FIELD_ACCESS)\n");
		nt = back_token();
		nt = back_token();
		parse_FIELD_ACCESS();
	}
	else if (nt->kind == TOKEN_OP_EQUAL || nt->kind == TOKEN_SEP_PARENTHESES_LEFT || nt->kind == TOKEN_AR_OP || nt->kind == TOKEN_SEP_SEMMICOLON || nt->kind == TOKEN_KEYWORD_END || nt->kind == TOKEN_SEP_SQR_BRACKET_LEFT || nt->kind == TOKEN_SEP_CURLY_BRACKET_LEFT)
	{
		fprintf(out_parser, "Rule(FIELD_ACCESS_TAG -> id)\n");
		nt = back_token();
	}
	else
	{
		fprintf(out_parser, "ERROR: excpected tokens: TOKEN_DOT,TOKEN_OP_EQUAL,TOKEN_SEP_PARENTHESES_LEFT,TOKEN_AR_OP, current token: %s, line: %d \n", getEnumTokenName(nt->kind), nt->lineNumber);
		while (nt->kind != TOKEN_OP_EQUAL && nt->kind != TOKEN_SEP_PARENTHESES_LEFT && nt->kind != TOKEN_SEP_SEMMICOLON && nt->kind != TOKEN_SEP_CURLY_BRACKET_LEFT && nt->kind != TOKEN_SEP_SQR_BRACKET_LEFT && nt->kind != TOKEN_KEYWORD_END && nt->kind != TOKEN_EOF) {
			nt = next_token();
		}
		nt = back_token();
	}
}



void parse_KEY()
{
	fprintf(out_parser, "Rule(KEY->VAR_ELEMENT)\n");
	parse_VAR_ELEMENT();
}


void parse_CASE_LIST()
{
	parse_CASE();
	parse_CASE_LIST_TAG();
}

void parse_CASE_LIST_TAG()
{
	eTOKENS kind;
	Token* nt = next_token();
	kind = nt->kind;
	switch (kind)
	{
	case TOKEN_KEYWORD_CASE:
	{
		fprintf(out_parser, "Rule(CASE_LIST_TAG->CASE CASE_LIST_TAG)\n");
		back_token();
		parse_CASE();
		parse_CASE_LIST_TAG();
		break;
	}
	case TOKEN_SEP_SEMMICOLON:
	{
		fprintf(out_parser, "Rule(CASE_LIST_TAG->epsilon)\n");
		nt = back_token();
		break;
	}
	default:
		fprintf(out_parser, "ERROR: excpected tokens: TOKEN_KEYWORD_CASE,TOKEN_SEP_SEMMICOLON, current token: %s, line: %d \n", getEnumTokenName(nt->kind), nt->lineNumber);
		while (nt->kind != TOKEN_SEP_SEMMICOLON && nt->kind != TOKEN_EOF) {
			nt = next_token();
		}
		nt = back_token();
		break;
	}
}




//void parse_CASE_LIST()
//{
//	eTOKENS kind;
//	Token* nt = next_token();
//	kind = nt->kind;
//	switch (kind)
//	{
//	case TOKEN_ID:
//	{
//		fprintf(out_parser, "Rule(CASE_LIST->id)\n");
//		parse_VAR_ELEMENT();
//		match(TOKEN_OP_EQUAL);
//		parse_EXPRESSION();
//		break;
//	}
//	case TOKEN_KEYWORD_SWITCH:
//	{
//		fprintf(out_parser, "Rule(CASE_LIST->SWITCH)\n");
//		match(TOKEN_SEP_PARENTHESES_LEFT);
//		parse_KEY();
//		match(TOKEN_SEP_PARENTHESES_RIGHT);
//		match(TOKEN_SEP_CURLY_BRACKET_LEFT);
//		parse_CASE_LIST();
//		match(TOKEN_SEP_SEMMICOLON);
//		match(TOKEN_KEYWORD_DEFAULT);
//		match(TOKEN_SEP_COLON);
//		parse_STATEMENTS();
//		match(TOKEN_SEP_CURLY_BRACKET_RIGHT);
//		break;
//	}
//	case TOKEN_KEYWORD_BREAK:
//	{
//		fprintf(out_parser, "Rule(CASE_LIST->BREAK)\n");
//		match(TOKEN_SEP_SEMMICOLON);
//		break;
//	}
//	case TOKEN_KEYWORD_BLOCK:
//	{
//		fprintf(out_parser, "Rule(CASE_LIST->BLOCK)\n");
//		parse_BLOCK();
//		break;
//	}
//	default:
//		//parser_error_handling(CASE_LIST, nt);
//		break;
//	}
//}
//
void parse_CASE()
{
	fprintf(out_parser, "Rule(CASE -> case KEY_VALUE : {STATEMENTS})\n");
	match(TOKEN_KEYWORD_CASE);
	parse_KEY_VALUE();
	match(TOKEN_SEP_COLON);
	match(TOKEN_SEP_CURLY_BRACKET_RIGHT);
	parse_STATEMENTS();
	match(TOKEN_SEP_CURLY_BRACKET_LEFT);
}

void parse_KEY_VALUE()
{
	eTOKENS kind;
	Token* nt = next_token();
	kind = nt->kind;
	switch (kind)
	{
	case TOKEN_INTEGER:
	{
		fprintf(out_parser, "Rule(KEY_VALUE->int_num)\n");
		break;
	}
	case TOKEN_ID:
	{
		fprintf(out_parser, "Rule(KEY_VALUE->id)\n");
		break;
	}
	default:
		fprintf(out_parser, "ERROR: excpected tokens: TOKEN_INTEGER,TOKEN_ID, current token: %s, line: %d \n", getEnumTokenName(nt->kind), nt->lineNumber);
		while (nt->kind != TOKEN_SEP_COLON && nt->kind != TOKEN_EOF) {
			nt = next_token();
		}
		nt = back_token();
		break;
	}
}


void parse_BB()
{
	if (root_table == NULL)
	{
		root_table = make_table(root_table);
		current_table = root_table;
	}
	else
		current_table = make_table(current_table);
}

void parse_FB()
{
	current_table = pop(current_table);

	if (current_table == NULL)
		root_table = NULL;
}