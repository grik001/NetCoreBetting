The below assumptions have been taken:

1) Project Manager is aware that this is a protorype
2) Security was not given a huge priority since this was a prototype
3) The Games will not be functional
4) Design was kept to the bareminum focusing on showing instant messageing and instant updates
5) The Technology used for the Front applications might not be what will be used when developing that actual applications
6) Message queues where not implmented since these required a seperate application to monitor queue and would added not substance to protortype
7) Service Fabric was also not implemented since the application can easily be presented using normal local/cloud hosting.
8) JWT refresh token has not been implemented, instead a long expiry time has been set. This is a must for production environments.
9) .Net core proved to be a limitation due to libraries not being production ready. Some custom implementation had to be used.
10) Role based authentication has been omitted from the API and will be developed for the production application
