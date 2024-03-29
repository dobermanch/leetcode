all:

.PHONY: tags
tags: 
	# Update tags section in README.md
	./scripts/update_readme.sh "README.md" "Tags"

.PHONY: code
code: 
	# Update code section in README.md
	./scripts/update_readme.sh "README.md" "Code"

path=""
.PHONY: rename_files
rename_files:
	# Rename files
	./scripts/rename_files.sh $(path)

.PHONY: configure_sql
configure_sql:
	# Configure MySQL
	./scripts/configure_mysql.sh

.PHONY: configure_pandas
configure_pandas:
	# Configure Pandas
	./scripts/configure_pandas.sh