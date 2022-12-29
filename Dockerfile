FROM mcr.microsoft.com/dotnet/sdk:6.0

# 設定工作目錄
WORKDIR /app

# 執行 dotnet restore 和 dotnet publish 指令
COPY *.csproj .
RUN dotnet restore

COPY . .
RUN dotnet publish -c Release -o out

# 將工作目錄設定為 /app/out
WORKDIR /app/out

# 設定 Docker 容器的自動重新啟動行為，並在重新啟動時強制關閉應用程式
ENTRYPOINT ["dotnet", "DCBot.dll"] && sleep 1 && pkill -f "dotnet"

