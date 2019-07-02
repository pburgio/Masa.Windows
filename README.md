# IoT Server
A Smart city server.

## Features

- Remote control for IoT-Semaphore via HTTP
- ...

<i>Warning</i>: it does <b>not</b> have a DB, so all stored data (e.g., Sem statuses) will be lost if you restart the server

## Getting started
This project is made by a Server part, which runs on IIS, and a client part, a simple website, which polls the WebApp using jQuery

In order to start the web application, simply load it in IIS, or run it in the IIS Express instance of Visual Studio by pressing F5.

The Web Console

### Configuration

Configure the server IP address inside Resources/library.js
It is typically "http://localhost", but you might want to change the port, e.g., in case you are using IISExpress

### Enable remote access for IISExpress

If you are running in IISExpress, e.g., from within Visual Studio, you must perform the following steps
1) Allow external requests by modifying the IIS configuration files, both "global" and "local to the project"
   
- https://www.ryadel.com/en/iis-express-allow-external-requests-remote-clients-devices/
- https://johan.driessen.se/posts/Accessing-an-IIS-Express-site-from-a-remote-computer/
   
2) Add Firewall Rule
- https://support.4it.com.au/article/add-additional-tcp-rule-windows-firewall-non-standard-rdp-port-windows-10/


### Contacts and credits

For any issues, feel free to contact gianluca DOT brilli  | paolo DOT burgio AT unimore DOT it

This work was supported by the Prystine Project, funded by Electronic Components and Systems for European Leadership Joint Undertaking (ECSEL JU) in collaboration with the European Union's H2020 Framework Programme and National Authorities, under grant agreement n° 783190, and by the Class project, funded by European Union’s Horizon 2020 research and innovation programme under the grant agreement No 780622.


![alt text](https://raw.githubusercontent.com/HiPeRT/IoT-Semaphore/master/img/class.png)

![alt text](https://raw.githubusercontent.com/HiPeRT/IoT-Semaphore/master/img/prystine.png)