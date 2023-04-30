# This is an experiment to deploy .Net 7 RESTful API solution to Docker and Azure ASK without Docker file
1. Create a .Net 7 Web API solution, minimal API works too, but it has to be .Net 7 or later  
2. Add Microsoft.NET.Build.Containers to your solution
3. Publish your code to local Docker instance using the following command:
    You need to describe the architecture of your CPU, in my case it is ARM64
    `dotnet publish --os linux --arch arm64 -c Release`
4. Run the application from the local Docker by the following command (you might need to adjust the command for your env):
    `docker run -it --rm -p 8080:80 [application name that docker has give with version]`

    