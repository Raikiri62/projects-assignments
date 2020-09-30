#include <stdlib.h>
#include <string.h>
#include "Token.h"
#include "SymbolTable.h"

Table *currentTable = NULL;

TableEntry *lookup(Table *curr, char *name)
{
	TableEntry *entry = NULL;

	// Check if the table pointer is not null and that at least 
	// one insert was made.
	if (curr != NULL && curr->entryList != NULL)
	{
		entry = curr->entryList;

		while (entry != NULL)
		{
			if (!strcmp(entry->name, name))
				return entry;

			if (entry->next != NULL)
				entry = entry->next;
			else
				break;
		}
	}

	return NULL;
}

TableEntry *insert(Table *curr, char *name)
{
	// Check if the id already exists in the table.
	TableEntry *entry = lookup(curr, name);
	if (entry != NULL)
		return NULL;

	// Insert to datastructure.
	else
		return addEntry(curr, name);
}


TableEntry *addEntry(Table *table, char *name)
{
	TableEntry *entry = NULL;

	// No entry has been inserted.
	if (table->entryList == NULL)
	{
		entry = (TableEntry *)malloc(sizeof(TableEntry));
		if (entry == NULL)
		{
			printf("ERROR: Unable to create table entry list.\n");
			exit(0);
		}

		table->entryList = entry;

		entry->prev = NULL;
		entry->next = NULL;
	}

	// More than one entries made.
	else
	{
		entry = table->entryList;

		// Go to the last entry in the list.
		while (entry->next != NULL) { entry = entry->next; }

		entry->next = (TableEntry *)malloc(sizeof(TableEntry));
		if (entry->next == NULL)
		{
			printf("ERROR: Unable to create table entry list.\n");
			exit(0);
		}

		// Set previous entry.
		entry->next->prev = entry;

		// Move to next entry.
		entry = entry->next;

		entry->next = NULL;
	}

	// Copy new id to table.
	strcpy(entry->name, name);

	return entry;
}

void set_id_type(TableEntry *entry, ElmType type)
{
	entry->type = type;
}

ElmType get_id_type(TableEntry *entry)
{
	return entry->type;
}

TableEntry *find(Table *curr, char *name)
{
	Table *currentTable = curr;
	TableEntry *entry = NULL;

	while (currentTable != NULL)
	{
		entry = lookup(currentTable, name);

		// Check if id is taken by entry in symbol table
		if (entry != NULL)
			return entry;
		else
			currentTable = currentTable->father;
	}

	return NULL;
}

Table *make_table(Table *curr)
{
	Table *currentTable = NULL;
	currentTable = (Table *)malloc(sizeof(Table));

	if (currentTable == NULL)
	{
		printf("ERROR: Unable to create symbol table.\n");
		exit(0);
	}

	currentTable->father = curr;

	currentTable->entryList = NULL;

	return currentTable;
}

Table *pop(Table *curr) // pop also delete the entries of curr table.
{
	TableEntry *entry, *temp;
	Table *fatherPtr = NULL;

	if (curr->father != NULL)
		fatherPtr = curr->father;

	entry = temp = curr->entryList;

	// Check if table is available.
	if (curr != NULL)
	{
		// Iterate list while possible.
		while (entry != NULL)
		{
			temp = entry;

			if (entry->next != NULL)
				entry = entry->next;
			else
			{
				free(temp);
				break;
			}

			free(temp);
		}

		free(curr);
	}

	return fatherPtr;
}