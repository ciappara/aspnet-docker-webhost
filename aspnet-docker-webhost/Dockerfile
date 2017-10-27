FROM microsoft/dotnet:latest

# Create directory from the app source code
RUN mkdir -p /usr/src/app
WORKDIR /usr/src/app

# Copy source code and restore dependencies
COPY . /usr/src/app
RUN dotnet restore

# Expose the port and start app
EXPOSE 36098
CMD [ "dotnet", "run" ]