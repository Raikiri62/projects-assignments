#ifndef TOKEN_H
#define TOKEN_H

#include <stdio.h>
#include <stdlib.h>
#include <string.h>

extern FILE *yyin, *yyout;

typedef enum eTOKENS
{
	TOKEN_KEYWORD_BLOCK,
	TOKEN_KEYWORD_END,
	TOKEN_KEYWORD_REAL,
	TOKEN_KEYWORD_INTEGER,
	TOKEN_KEYWORD_BEGIN,
	TOKEN_KEYWORD_ARRAY,
	TOKEN_KEYWORD_OF,
	TOKEN_KEYWORD_TYPE,
	TOKEN_KEYWORD_IS, 
	TOKEN_KEYWORD_ENUM,
	TOKEN_KEYWORD_STRUCT,
	TOKEN_KEYWORD_SWITCH,
	TOKEN_KEYWORD_DEFAULT,
	TOKEN_KEYWORD_BREAK,
	TOKEN_KEYWORD_CASE,
	TOKEN_OP_EQUAL,
	TOKEN_AR_OP,
	TOKEN_DOT,
	TOKEN_SEP_COMMA,
	TOKEN_SEP_SEMMICOLON,
	TOKEN_SEP_COLON,
	TOKEN_SEP_PARENTHESES_RIGHT,
	TOKEN_SEP_PARENTHESES_LEFT,
	TOKEN_SEP_SQR_BRACKET_RIGHT,
	TOKEN_SEP_SQR_BRACKET_LEFT,
	TOKEN_SEP_CURLY_BRACKET_RIGHT,
	TOKEN_SEP_CURLY_BRACKET_LEFT,
	TOKEN_EOF,
	TOKEN_ID,
	TOKEN_TYPE_NAME,
	TOKEN_REAL,
	TOKEN_INTEGER,
}eTOKENS;

typedef struct Token
{
	eTOKENS kind;
	char *lexeme;
	int lineNumber;
}Token;

typedef struct Node
{
	Token *tokensArray;
	struct Node *prev;
	struct Node *next;
} Node;

typedef struct node_list
{
	Node *first_node;
	Node *last_node;
	int nodes_count;
} node_list;

void create_and_store_token(eTOKENS kind, char* lexeme, int numOfLine);
Token *next_token();
Token *back_token();
int match(eTOKENS token_kind);
//void removeTokensList();
void free_token_list();
eTOKENS Handle_token(eTOKENS, char*, int);
const char* getEnumTokenName(enum eTOKENS enumTok);
Token *baba();
void reverseList();
#endif