Important Info:

For demo purpose In program.cs i used the below line

// Configure the HTTP request pipeline. //dont do this in production
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}


Steps: 

1. Go to https://labs.play-with-docker.com/
2. Add new instance by clicking "ADD NEW INSTANCE"
3. run command "git clone https://github.com/ironpython2001/dotnet-core-file-type-signature-verifier.git"
4. cd dotnet-core-file-type-signature-verifier
5. cd FileTypeVerifierConsole
6. navigate to the directory 
7. docker build . -t filetypeverifierapi-image
8. docker run --name filetypeverifierapi-image -p 8081:80 -d filetypeverifierapi-image
9. port 8081 will be opened
10. Click on the port number 8081 on the ui and append "swagger/index.html"
ex: 
http://ip172-18-0-4-c76p8hdmrepg00fav2p0-8081.direct.labs.play-with-docker.com/swagger/index.html



URLS:
-----
https://www.c-sharpcorner.com/article/building-and-running-asp-net-core-application-in-docker-container/
https://www.c-sharpcorner.com/article/run-and-test-asp-net-core-web-api-docker-container-locally/
https://dev.to/berviantoleo/web-api-in-net-6-docker-41d5
https://blog.sixeyed.com/experimenting-with-net-5-and-6-using-docker-containers/
