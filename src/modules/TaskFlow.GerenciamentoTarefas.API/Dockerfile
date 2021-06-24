#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/modules/TaskFlow.GerenciamentoTarefas.API/TaskFlow.GerenciamentoTarefas.API.csproj", "src/modules/TaskFlow.GerenciamentoTarefas.API/"]
RUN dotnet restore "src/modules/TaskFlow.GerenciamentoTarefas.API/TaskFlow.GerenciamentoTarefas.API.csproj"
COPY . .
WORKDIR "/src/src/modules/TaskFlow.GerenciamentoTarefas.API"
RUN dotnet build "TaskFlow.GerenciamentoTarefas.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TaskFlow.GerenciamentoTarefas.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TaskFlow.GerenciamentoTarefas.API.dll"]