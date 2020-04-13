@echo off

SET NAME=%1
dotnet ef --startup-project ..\Web\Sicle.Web.csproj migrations add %NAME%
