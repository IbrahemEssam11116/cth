dotnet build .\DAL\DatabaseGeneric\SStorm.CTH.DAL.csproj -p:Version=2.1.700  --configuration Release --output .\DAL\Bin\Release

dotnet build .\DAL\DatabaseSpecific\SStorm.CTH.DALDBSpecific.csproj -p:Version=2.1.700  --configuration Release --output .\DAL\Bin\Release



copy .\DAL\Bin\Release\*.dll ..\LIB /y

copy .\DAL\Bin\Release\*.xml ..\LIB /y

pause


