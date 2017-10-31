## MercuryNorth asp.net
A simple asp.net mvc project for demos and experiments.

The idea being this simple landing page can be used to demo a simple website for deployments, experiments, and other related tasks.

By itself, the site should build without any problems. There is not any use of NPM or Bower, as all 3rd party components is being retrieved from NuGet. Deployment should be simple depending on your Modus operandi.

The site is targeted to use .net framework 4.6.2.

There is not a lot of c# code invovled with the application, just enough to randomly display a date, as well as the machine name.

### Running on Docker
Included in Source is a Dockerfile for complete end-to-end building of the container. There is no need for Visual Studio to build and deploy the code into the container, as the Dockerfile is configured to do this for you.

On a personal note, this Dockerfile is a lot more complicated and is much larger in size as other frameworks. This Dockerfie should be a decent template to accomplish similar goals with other asp.net projects.

To begin, first build:

```
docker build -t mercurynorth-dotnet .
```

... then once the container is build, running it is as simple as:

```
run -d --name mercurynorth mercurynorth-dotnet
```

... there should be no reason to expose a port, as the image being built will expose that for you.

NOTE: With the current Windows Container release, you can't browse to http://localhost. This is a known behavior in WinNAT, and it will be resolved in the future. Until that is addressed, you need to use the IP address of the container.

```
docker inspect -f "{{ .NetworkSettings.Networks.nat.IPAddress }}" mercurynorth
172.31.194.61
```
Connect to the running container using the IPv4 address, http://172.31.194.61 in the example shown. Type that URL into your browser, and you should see the running site.

### License(s)

Copyright (c) 2007 - Casey Kriutzfield.

Live Site: [MercuryNorth.us](http://mercurynorth.us).

Licensed on the MIT License. Users are free to fork the code and update and modify to suit their needs as part of demo's, etc.

Original Design - Start Bootstrap - Landing Page (http://startbootstrap.com/).

Copyright 2013-2016 Start Bootstrap.

Licensed under [MIT](https://github.com/BlackrockDigital/startbootstrap/blob/gh-pages/LICENSE)