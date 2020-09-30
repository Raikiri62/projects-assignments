%option noyywrap
%{
#include <stdio.h>

#include "Token.h"
#include "Parser.h"

extern FILE *out_parser;

#define TESTS 2

void error(char*,int);

int LineCounter=-1;

%}

DIGIT [0-9]
CHAR	[a-zA-Z]
%%
[ \t] {}
"$$".*	;
"block"	{Handle_token(TOKEN_KEYWORD_BLOCK, "keyword block", LineCounter);}
"end"	{Handle_token(TOKEN_KEYWORD_END, "keyword end", LineCounter);}
"real"	{Handle_token(TOKEN_KEYWORD_REAL, "keyword real", LineCounter);}
"integer"	{Handle_token(TOKEN_KEYWORD_INTEGER, "keyword integer", LineCounter);}
"begin"	{Handle_token(TOKEN_KEYWORD_BEGIN, "keyword begin", LineCounter);}
"array"	{Handle_token(TOKEN_KEYWORD_ARRAY, "keyword array", LineCounter);}
"of"	{Handle_token(TOKEN_KEYWORD_OF, "keyword of", LineCounter);}
"type"	{Handle_token(TOKEN_KEYWORD_TYPE, "keyword type", LineCounter);}
"is"	{Handle_token(TOKEN_KEYWORD_IS, "keyword is", LineCounter);}
"enum"	{Handle_token(TOKEN_KEYWORD_ENUM, "keyword enum", LineCounter);}
"struct"	{Handle_token(TOKEN_KEYWORD_STRUCT, "keyword struct", LineCounter);}
"switch"	{Handle_token(TOKEN_KEYWORD_SWITCH, "keyword switch", LineCounter);}
"default"	{Handle_token(TOKEN_KEYWORD_DEFAULT, "keyword default", LineCounter);}
"break"	{Handle_token(TOKEN_KEYWORD_BREAK, "keyword break", LineCounter);}
"case"	{Handle_token(TOKEN_KEYWORD_CASE, "keyword case", LineCounter);}
"="	{Handle_token(TOKEN_OP_EQUAL, "operator EQUAL", LineCounter);}
"*"	{Handle_token(TOKEN_AR_OP, "operator MULTIPICATION", LineCounter);}
"+"	{Handle_token(TOKEN_AR_OP, "operator ADDITION", LineCounter);}
"-"	{Handle_token(TOKEN_AR_OP, "operator SUBSTRUCTION", LineCounter);}
"."	{Handle_token(TOKEN_DOT, "TOKEN DOT ACCESS", LineCounter);}
"/"	{Handle_token(TOKEN_AR_OP, "operator DIVISION", LineCounter);}
","	{Handle_token(TOKEN_SEP_COMMA, "Comma seperator", LineCounter);}
";"	{Handle_token(TOKEN_SEP_SEMMICOLON, "SEMMICOLON seperator", LineCounter);}
":"	{Handle_token(TOKEN_SEP_COLON, "COLON seperator", LineCounter);}
"("	{Handle_token(TOKEN_SEP_PARENTHESES_RIGHT, "right parentheses seperator", LineCounter);}
")"	{Handle_token(TOKEN_SEP_PARENTHESES_LEFT, "left parentheses seperator", LineCounter);}
"["	{Handle_token(TOKEN_SEP_SQR_BRACKET_RIGHT, "right Square bracket seperator", LineCounter);}
"]"	{Handle_token(TOKEN_SEP_SQR_BRACKET_LEFT, "left Square bracket seperator", LineCounter);}
"{"	{Handle_token(TOKEN_SEP_CURLY_BRACKET_RIGHT, "right CURLY bracket seperator", LineCounter);}
"}"	{Handle_token(TOKEN_SEP_CURLY_BRACKET_LEFT, "left CURLY bracket seperator", LineCounter);}
<<EOF>> {Handle_token(TOKEN_EOF, yytext, LineCounter); return 1;}
\n	LineCounter++;

({CHAR}(({CHAR}*{DIGIT}*|"_")({CHAR}|{DIGIT})+)*)	{Handle_token(TOKEN_ID, yytext, LineCounter);}
[_]({CHAR}(({CHAR}*{DIGIT}*|"_")({CHAR}|{DIGIT})+)*)	{Handle_token(TOKEN_TYPE_NAME, yytext, LineCounter);}
(0|[1-9][0-9]*)\.[0-9]+	{Handle_token(TOKEN_REAL, yytext, LineCounter);}
(0|0*[1-9]{DIGIT}*|[1-9]{DIGIT}*)	{Handle_token(TOKEN_INTEGER, yytext, LineCounter);}
.        {fprintf(yyout, "The character %s at line %d does not begin any legal token in the language.\n",yytext,LineCounter);}

%%

void error(char *lexeme ,int lineNum)
{
	printf("error: unrecognized character in line %4d: %4s\n",lineNum,lexeme);
}

void parser()
{
	parse_PROGRAM();
	match(TOK_EOF);
}

int main(int argc, char *argv[])
{

	int test;

	char filename[100] = { 0 };

	eTOKENS kind;

	for (test = 1; test <= TESTS; test++)
	{
		// Generating input file name
		sprintf(filename, "%s%d%s", "C:\\temp\\test", test, ".txt");

		// Get source code file.
		if (!(yyin = fopen(filename, "r")))
		{
			printf("cannot open input file %s; please press any key to continue", filename);
			getchar();
			continue;
		}
		else
		{
			LineCounter = 1;

			/*generating output file name*/
			sprintf(filename, "%s%d%s", "C:\\temp\\test", test, "_305608275_313175192_lex.txt");

			// Lexer
			if (!(yyout = fopen(filename, "w")))
			{
				printf("cannot open lex output file %s; please press any key to continue", filename);
				getchar();
				continue;
			}
			else
			{
				// Parser
				sprintf(filename, "%s%d%s", "C:\\temp\\test", test, "_305608275_313175192_syntactic.txt");

				if (!(out_parser = fopen(filename, "w")))
				{
					printf("cannot open parser output file %s; please press any key to continue", filename);
					getchar();
					continue;
				}
				else
				{
					yylex();
					reverseList();
					parser();
					free_token_list();
				}
			}
		}

		/*close files*/
		if (yyin != NULL)
			fclose(yyin);
		if (yyout != NULL)
			fclose(yyout);
		if (out_parser != NULL)
			fclose(out_parser);
	}

	/****************************************************
	PAUSE TO SEE ERROR MSG: START
	*****************************************************/
	printf("\nPAUSE TO SEE ERROR MSG: Press any key to continue\n");
	getchar();

	/****************************************************
	PAUSE TO SEE ERROR MSG: END
	*****************************************************/
	return 0;
}

