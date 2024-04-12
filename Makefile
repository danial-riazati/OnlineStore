MIGRATION_NAME ?= DefaultName
PROJECT_PATH ?= OnlineStore.Infrastructure
STARTUP_PROJECT_PATH ?= OnlineStore

.PHONY: migration add-migration update-database

migration add-migration:
	@echo "Adding migration $(MIGRATION_NAME)..."
	dotnet ef migrations add $(MIGRATION_NAME) --project $(PROJECT_PATH) --startup-project $(STARTUP_PROJECT_PATH) -v

update-database:
	@echo "Updating database..."
	dotnet ef database update --project $(PROJECT_PATH) --startup-project $(STARTUP_PROJECT_PATH) -v


