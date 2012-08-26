Some fun with log4net and sqlite.

Table schema: Location (string), Level(string), Message (ntext), TimeStamp (DateTime).

I tried to keep this as simple as possible. You can probably expand this to suit your specific needs. 

Level/Message/TimeStamp are self explanatory. They are part of the defaults given by log4net. Location is a little different. The idea is to change this value to a specific office/location a company may have accross the country or the world. It can probably be removed. 

Notes: You need to change the connection string to the proper location in your machine. I hard-coded the location of my database. I know, I know bad developer. I'll revisit it in the future, I promise.
