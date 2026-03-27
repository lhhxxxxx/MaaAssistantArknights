cd..
cmake --install build --config RelWithDebInfo --prefix ./install
dotnet publish src/MaaWpfGui/MaaWpfGui.csproj -c Release -o install -p:Platform=x64
Remove-Item -Path .\install\*.h -Force
robocopy .\resource .\install\resource /MIR /MT:8