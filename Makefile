build:
	dotnet restore --use-lock-file
	dotnet build --no-restore

buildd:
	docker build --build-arg NUGET_USER=${NUGET_USER} --build-arg NUGET_TOKEN=${NUGET_TOKEN} .

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

clear-cache:
	dotnet nuget locals all --clear