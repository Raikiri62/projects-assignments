#include "Token.h"

/* This package describes the storage of tokens identified in the input text.
* The storage is a bi-directional list of nodes.
* Each node is an array of tokens; the size of this array is defined as TOKEN_ARRAY_SIZE.
* Such data structure supports an efficient way to manipulate tokens.

There are three functions providing an external access to the storage:
- function create_and_store_tokens ; it is called by the lexical analyzer when it identifies a legal token in the input text.
- functions next_token and back_token; they are called by parser during the syntax analysis (the second stage of compilation)
*/

//extern void yylex();

int backTokenCount = 0;
int currentIndex = 0;
Node* currentNode = NULL;
node_list nodes_list = { NULL, NULL, 0 };
#define TOKEN_ARRAY_SIZE 100

const char* getEnumTokenName(enum eTOKENS enumTok)
{
	switch (enumTok)
	{
	case TOKEN_KEYWORD_BLOCK: return "TOKEN_KEYWORD_BLOCK";
	case TOKEN_KEYWORD_END: return "TOKEN_KEYWORD_END";
	case TOKEN_KEYWORD_REAL: return "TOKEN_KEYWORD_REAL";
	case TOKEN_KEYWORD_INTEGER: return "TOKEN_KEYWORD_INTEGER";
	case TOKEN_KEYWORD_BEGIN: return "TOKEN_KEYWORD_BEGIN";
	case TOKEN_KEYWORD_ARRAY: return "TOKEN_KEYWORD_ARRAY";
	case TOKEN_KEYWORD_OF: return "TOKEN_KEYWORD_OF";
	case TOKEN_KEYWORD_TYPE: return "TOKEN_KEYWORD_TYPE";
	case TOKEN_KEYWORD_IS: return "TOKEN_KEYWORD_IS";
	case TOKEN_KEYWORD_ENUM: return "TOKEN_KEYWORD_ENUM";
	case TOKEN_KEYWORD_STRUCT: return "TOKEN_KEYWORD_STRUCT";
	case TOKEN_KEYWORD_SWITCH: return "TOKEN_KEYWORD_SWITCH";
	case TOKEN_KEYWORD_DEFAULT: return "TOKEN_KEYWORD_DEFAULT";
	case TOKEN_KEYWORD_BREAK: return "TOKEN_KEYWORD_BREAK";
	case TOKEN_KEYWORD_CASE: return "TOKEN_KEYWORD_CASE";
	case TOKEN_OP_EQUAL: return "TOKEN_OP_EQUAL";
	case TOKEN_DOT: return "TOKEN_DOT";
	case TOKEN_AR_OP: return "TOKEN_AR_OP";
	case TOKEN_SEP_COMMA: return "TOKEN_SEP_COMMA";
	case TOKEN_SEP_SEMMICOLON: return "TOKEN_SEP_SEMMICOLON";
	case TOKEN_SEP_COLON: return "TOKEN_SEP_COLON";
	case TOKEN_SEP_PARENTHESES_RIGHT: return "TOKEN_SEP_PARENTHESES_RIGHT";
	case TOKEN_SEP_PARENTHESES_LEFT: return "TOKEN_SEP_PARENTHESES_LEFT";
	case TOKEN_SEP_SQR_BRACKET_RIGHT: return "TOKEN_SEP_SQR_BRACKET_RIGHT";
	case TOKEN_SEP_SQR_BRACKET_LEFT: return "TOKEN_SEP_SQR_BRACKET_LEFT";
	case TOKEN_SEP_CURLY_BRACKET_RIGHT: return "TOKEN_SEP_CURLY_BRACKET_RIGHT";
	case TOKEN_SEP_CURLY_BRACKET_LEFT: return "TOKEN_SEP_CURLY_BRACKET_LEFT";
	case TOKEN_EOF: return "TOKEN_EOF";
	case TOKEN_ID: return "TOKEN_ID";
	case TOKEN_TYPE_NAME: return "TOKEN_TYPE_NAME";
	case TOKEN_REAL: return "TOKEN_REAL";
	case TOKEN_INTEGER: return "TOKEN_INTEGER";
		//case TOKEN_ILLIGAL_CHARACTER: retuen
	}
	return "not good";
}

/*
* This function creates a token and stores it in the storage.
*/
void create_and_store_token(eTOKENS kind, char* lexeme, int numOfLine)
{
	int length = strlen(lexeme) + 1;

	// case 1: there is still no tokens in the storage.
	if (currentNode == NULL)
	{
		currentNode = (Node*)malloc(sizeof(Node));

		if (currentNode == NULL)
		{
			fprintf(yyout, "\nUnable to allocate memory! \n");
			exit(0);
		}
		currentNode->tokensArray = (Token*)calloc(sizeof(Token), TOKEN_ARRAY_SIZE);
		if (currentNode->tokensArray == NULL)
		{
			fprintf(yyout, "\nUnable to allocate memory! \n");
			exit(0);
		}
		currentNode->prev = NULL;
		currentNode->next = NULL;
		nodes_list.first_node = currentNode;
		nodes_list.last_node = currentNode;
		nodes_list.nodes_count++;
	}

	// case 2: at least one token exsits in the storage.
	else
	{
		// the array (the current node) is full, need to allocate a new node
		if (currentIndex == TOKEN_ARRAY_SIZE - 1)
		{
			currentIndex = 0;
			currentNode->next = (Node*)malloc(sizeof(Node));

			if (currentNode == NULL)
			{
				fprintf(yyout, "\nUnable to allocate memory! \n");
				exit(0);
			}
			currentNode->next->prev = currentNode;
			currentNode = currentNode->next;
			currentNode->tokensArray = (Token*)calloc(sizeof(Token), TOKEN_ARRAY_SIZE);

			if (currentNode->tokensArray == NULL)
			{
				fprintf(yyout, "\nUnable to allocate memory! \n");
				exit(0);
			}
			currentNode->next = NULL;
			currentNode->prev = nodes_list.last_node;
			nodes_list.last_node->next = currentNode;
			nodes_list.last_node = currentNode;
			nodes_list.nodes_count++;
		}

		// the array (the current node) is not full
		else
		{
			currentIndex++;
		}
	}

	currentNode->tokensArray[currentIndex].kind = kind;
	currentNode->tokensArray[currentIndex].lineNumber = numOfLine;

	currentNode->tokensArray[currentIndex].lexeme = (char*)malloc(sizeof(char)*length);
#ifdef _WIN32
	strcpy_s(currentNode->tokensArray[currentIndex].lexeme, length, lexeme);
#else
	strcpy(currentNode->tokensArray[currentIndex].lexeme, lexeme);
#endif		
}

eTOKENS Handle_token(eTOKENS kind, char *lexeme, int lineNum)
{
	create_and_store_token(kind, lexeme, lineNum);

	fprintf(yyout, "Token of kind: %-20s \t found at line: %3d. \t lexeme: %s\n", getEnumTokenName(kind), lineNum, lexeme);

	return kind;
}

Token *back_token()
{
	// case 1: there are no tokens in the storage.
	if (currentNode == NULL)
		fprintf(yyout, "\nNo tokens has been stored! \n");

	// case 2: at least one token exists in the storage.
	else
	{
		// case 3: index at beginning of array.
		if (currentIndex == 0)
		{
			// case 3a: no previous node available.
			if (currentNode->prev == NULL)
			{
				fprintf(yyout, "\nNot possible to get previous token! \n");
				return NULL;
			}

			currentNode = currentNode->prev;
			currentIndex = TOKEN_ARRAY_SIZE - 1;
		}

		// case 4: index has not reached beginning of array.
		else
		{
			currentIndex--;
		}
	}
	return &currentNode->tokensArray[currentIndex];
}

Token *next_token()
{
	if (currentNode != NULL)
	{
		// case 1: there are no tokens in the storage.
		/*if (currentNode == NULL)
			fprintf(yyout, "\nNo tokens has been stored! \n");*/

		// case 2: at least one token exists in the storage.

			// case 3: index has reached end of array.
			if (currentIndex == TOKEN_ARRAY_SIZE - 1)
			{
				// case 3a: there are no more forward nodes to traverse.
				if (currentNode->next == NULL)
				{
					fprintf(yyout, "\nLast token reached. \n");
					return NULL;
				}

				currentNode = currentNode->next;
				currentIndex = 0;
			}

			// case4: index has not reached end of array.
		

		backTokenCount--;
	}

	//else {
	//	yylex();
	//	reverseList();
	//}
	return &currentNode->tokensArray[currentIndex++];
}
void reverseList() {
	currentNode = nodes_list.first_node;
	currentIndex = 0;
}
Token *baba() {
	return &currentNode->tokensArray[currentIndex++];
}

// Free token linked list.
void free_token_list()
{
	// reset index.
	currentIndex = 0;

	// traverse to start of list.
	while (currentNode->prev != NULL)
	{
		currentNode = currentNode->prev;
	}

	// free nodes.
	while (currentNode != NULL)
	{
		Node *temp = currentNode;

		// traverse to next node.
		if (currentNode->next != NULL)
		{
			currentNode = currentNode->next;
			currentNode->prev = NULL;
		}
		else
			// last node.
			currentNode = NULL;

		free(temp->tokensArray);
		free(temp);
	}
}

