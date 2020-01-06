FROM microsoft/dotnet:sdk as publish
WORKDIR /publish
COPY Vision.csproj .
RUN dotnet restore
COPY . .
RUN dotnet publish --output ./out

FROM microsoft/dotnet:aspnetcore-runtime
LABEL author="Santosh" 
WORKDIR /var/www/visioninspectionapp
COPY --from=publish /publish/out .
ENV ASPNETCORE_URLS=http://*:5000
ENV ASPNETCORE_ENVIRONMENT=production
EXPOSE 5000
ENTRYPOINT ["dotnet", "Vision.dll"]