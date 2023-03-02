build:
	dotnet restore --use-lock-file
	dotnet build --no-restore

run:
	dotnet run

clean:
	dotnet clean

fix:
	dotnet format

up:
	docker-compose up -d

down:
	docker-compose down