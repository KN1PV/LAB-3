# ������������� ������� ����� �� .NET SDK
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app

# ������� ����� � ���������
COPY . ./

# ³��������� ��������� �� ������� ������
RUN dotnet restore
RUN dotnet publish -c Release -o out

# ������������� ����� �� .NET Runtime ��� �������
FROM mcr.microsoft.com/dotnet/runtime:7.0
WORKDIR /app
COPY --from=build /app/out .

# ��������� �������
ENTRYPOINT ["dotnet", "LibraryManagementDemo.dll"]
