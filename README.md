
Application:
http://localhost:57919/


WebAPI
http://localhost:57919/api/notes  (only GET and POST is implemented)


Request : HTTPGET - 
Response : 

[
 {"Id":1,"Lattitude":-37.5984421,"Longitude":144.941818,"UserName":"test","Note":"this is test note"},
 {"Id":2,"Lattitude":-37.6691437,"Longitude":144.543716,"UserName":"test1","Note":"this is test1 note"},
 {"Id":3,"Lattitude":-37.8173065,"Longitude":144.935043,"UserName":"jitu","Note":"jitu note"},
 {"Id":4,"Lattitude":-37.8100433,"Longitude":144.957123,"UserName":"jhon","Note":"hello"},
 {"Id":5,"Lattitude":-37.8127327,"Longitude":144.973526,"UserName":"Rock","Note":"Rock House"},
 {"Id":6,"Lattitude":-37.8150063,"Longitude":144.966873,"UserName":"Ramesh","Note":"Ramesh House"},
 {"Id":7,"Lattitude":-37.8100548,"Longitude":144.9764,"UserName":"test","Note":"hello melboure"},
 {"Id":8,"Lattitude":-37.811142,"Longitude":144.946228,"UserName":"Hall","Note":"Hall of Fame"},
 {"Id":9,"Lattitude":-37.8090363,"Longitude":144.99,"UserName":"bunning","Note":"bunning building"},
 {"Id":10,"Lattitude":-37.8152962,"Longitude":144.956985,"UserName":"Ram","Note":"Ram Remark"},
 {"Id":11,"Lattitude":-37.8152962,"Longitude":144.956985,"UserName":"Jitu","Note":"Jitu is Good Boy"},
 {"Id":12,"Lattitude":-37.6846237,"Longitude":145.146225,"UserName":"Richard","Note":"Richard PArking"}
]


Request : HTTPPOST - 
{"Lattitude":"-37.8273065","Longitude":"144.955043","UserName":"rock","Note":"rock note"}

Response : <bool> true or false


1. As a user (of the application) I can see my current location on a map

Answer: Current location is shown if not default location is shown. 

2. As a user I can save a short note at my current location

Answer: Post notes using the current location or choose any location by clicking on the map

3. As a user I can see notes that I have saved at the location they were saved on the map

Answer: All notes are displayed by default

4. As a user I can see the location, text, and user-name of notes other users have saved

Answer: All notes from all users are displayed by default

5. As a user I have the ability to search for a note based on contained text or user-nameAnswer: Current can search on username and remark text