FROM microsoft/dotnet-framework:4.6.2 as builder

# First Step is to build the code and prepare it to be deployed. This will all be done here in the intermediate container.
# The microsoft/dotnet-framework:4.6.2 image above contains the .net framework along with MSBuild, which we need.

# Going to be running some commands, so lets do it in PowerShell
SHELL ["powershell", "-Command", "$ErrorActionPreference = 'Stop'; $ProgressPreference = 'SilentlyContinue';"]

# Add NuGet. This is so we can get the Targeting Files. We need these targeting files to build!
RUN Invoke-WebRequest "https://dist.nuget.org/win-x86-commandline/latest/nuget.exe" -OutFile "C:\windows\nuget.exe" -UseBasicParsing  

# Install Web Targets. Basically we take them from the folder on C:\, and put them were it needs to be.
RUN &  "C:\windows\nuget.exe" Install MSBuild.Microsoft.VisualStudio.Web.targets -Version 12.0.4
RUN New-Item 'C:\Program Files (x86)\MSBuild\Microsoft\VisualStudio\v12.0' -type directory
RUN mv 'C:\MSBuild.Microsoft.VisualStudio.Web.targets.12.0.4\tools\VSToolsPath\*' 'C:\Program Files (x86)\MSBuild\Microsoft\VisualStudio\v12.0'  

# Now we create a place to copy the solution into.
RUN mkdir /app
WORKDIR /app
copy . .

# Now that the applicaion is on the container. Lets restore the packages.
RUN "C:\windows\nuget.exe" restore C:\app\mercurynorth.sln

# Fun fact, this is where MSBuild is, so if we set this as our working directory, we can build and prep the application for deployment.
WORKDIR /Windows/Microsoft.NET/Framework/v4.0.30319

# Now to Build! VisualStudioVersion is based on the targets we have above, and WebPublishMethod as FileSystem gives us a good way to have files ready to deploy. 
RUN .\MSBuild.exe C:\app\MercuryNorth.sln /p:VisualStudioVersion=12.0 /p:DeployOnBuild=true /p:DeployDefaultTarget=WebPublish /p:WebPublishMethod=FileSystem /p:publishUrl=/output

# At this point, we should have a built and ready to be deployed app in the C:\output directory. 

# Now to create the container that will host the website.
FROM microsoft/aspnet:4.6.2

# Copy the files from the builder container above, into this one. By placing it in /inetpub/wwwroot, we are set to go.
COPY --from=builder output /inetpub/wwwroot