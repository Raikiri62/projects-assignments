#pragma once
#include <stdio.h>

#define ID_NAME_LENGTH 100
#define MAX_PARAM 100

typedef enum elm_type
{
	INTEGER,
	REAL,
	TYPE_NAME
} ElmType;

typedef enum complex_type
{
	STRUCTURE,
	ENUMERATION
} Complex_type;

typedef struct variable
{
	ElmType param_type;
	int array_size; // if the variable is array, then "array_size" is defined, and also its type as requested.
} Variable;

typedef struct type
{
	Complex_type param_type;
	Variable parameters[MAX_PARAM]; // for struct
	char *enum_fields[MAX_PARAM]; // for enum
} Type;


typedef struct table_entry
{
	char name[ID_NAME_LENGTH];
	ElmType type;
	int is_Type;

	union
	{
		Variable var;
		Type type;
	};

	struct table_entry *next;
	struct table_entry *prev;

} TableEntry;

typedef struct table
{
	struct table *father;

	TableEntry *entryList;

} Table;

TableEntry *addEntry(Table *table, char *name);

void set_id_type(TableEntry *entry, ElmType type);
ElmType get_id_type(TableEntry *entry);

TableEntry *lookup(Table *curr, char *name);
TableEntry *insert(Table *curr, char *name);
TableEntry *find(Table *curr, char *name);
Table *make_table(Table *curr);
Table *pop(Table *curr);


