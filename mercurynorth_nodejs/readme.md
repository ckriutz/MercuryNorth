# MercuryNorth node.js
A simple node.js project for demos and experiments.

The idea being this landing page can be used to demo a simple website for deployments, experiments, etc.

Originally, the design for the site came from:
 Start Bootstrap - Landing Page (http://startbootstrap.com/)
 Copyright 2013-2016 Start Bootstrap
 Licensed under MIT (https://github.com/BlackrockDigital/startbootstrap/blob/gh-pages/LICENSE)

...however many changes have been made to the application since then to reflect the nature of the site.

In order to dynamically add some of the data (year, machine name) I altered the site to use ejs (http://ejs.co/).

In order to add to the experimental nature of the application I plan to add:

* A REST Endpoint.
* Data that is retrieved from a data store such as a Database, JSON file, Redis, or DocumentDB.
* A Form that can be filled out and the data stored.

...this way we can take advantage of watching those items as part of a container, microservice, or load balanced, etc.
