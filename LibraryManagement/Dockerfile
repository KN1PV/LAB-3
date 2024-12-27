# Використовуємо базовий образ із .NET SDK
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app

# Копіюємо проєкт у контейнер
COPY . ./

# Відновлюємо залежності та збираємо рішення
RUN dotnet restore
RUN dotnet publish -c Release -o out

# Використовуємо образ із .NET Runtime для запуску
FROM mcr.microsoft.com/dotnet/runtime:7.0
WORKDIR /app
COPY --from=build /app/out .

# Запускаємо додаток
ENTRYPOINT ["dotnet", "LibraryManagementDemo.dll"]
