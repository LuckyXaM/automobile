 FROM microsoft/aspnetcore-build:2.0 
 WORKDIR /app


 COPY ./AutoRepository AutoRepository
 COPY ./AutoRepository.Data AutoRepository.Data
 COPY ./AutoRepository.Services AutoRepository.Services

 WORKDIR /app/AutoRepository
 RUN dotnet restore /app/AutoRepository/AutoRepository.csproj
 RUN dotnet publish -c Release -o build

 WORKDIR /app/AutoRepository/build
 RUN ls
 ENTRYPOINT /bin/bash -c "dotnet AutoRepository.dll"
