FROM mcr.microsoft.com/dotnet/sdk:6.0

# 設定工作目錄
WORKDIR /app

# 將所有檔案拷貝到工作目錄中
COPY . .

# 執行 dotnet restore 和 dotnet publish 指令
RUN dotnet restore
RUN dotnet publish -c Release -o out

# 將工作目錄設定為 /app/out
WORKDIR /app/out

# 設定 ENTRYPOINT 指令
ENTRYPOINT ["dotnet", "DCBot.dll"]
