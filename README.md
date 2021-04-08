# Music-Service

### Description
Rest API service for adding, updating, and removing uploaded music files and playlists for RevMixer.  

#### API Controllers
<table>
<tr><th><h3>Upload Music</h3></th><th><h3>PlayList</h3></th><th><h3>MusicPlaylist</h3></th><th><h3>Comments</h3></th></tr>
<tr>
<th><h4>Endpoints</h4></th>
</tr>
<tr>
<td>

|Get / Post| Get / Put / Delete|
|--|--|--|
/api/UploadMusic | /api/UploadMusic/{id}

</td><td>

|Get / Post| Get / Put / Delete|
|--|--|--|
/api/ | /api/

</td>
<td>

|Get / Post| Get / Put / Delete|
|--|--|--|
/api/ | /api/

</td><td>

|Get / Post| Get / Put / Delete|
|--|--|--|
/api/ | /api/

</td>
</tr> 

<tr>
<th><h4>Model Properties</h4></th>
</tr>

<td>

DataType | Variable
----|----
int|Id
int|userId
string|musicFilePath
string|name
DateTime|uploadDate
int|likes
int|plays
ICollection\<MusicPlaylist>|musicPlaylists
ICollection\<Comments>|comments
bool|isPrivate
bool|isApproved
bool|isLocked

</td>
<td>

DataType | Variable
----|----
int|Id
int|userId
string|name
ICollection\<MusicPlaylist>|musicPlaylist

</td>
<td>

DataType | Variable
----|----
int|Id
int|playListId
PlayList|playList
UploadMusic|uploadMusic
int|musicId

</td>
<td>

DataType | Variable
----|----
int|Id
string|comment
DateTime|commentDate
int|userId
int|uploadMusicId
UploadMusic|uploadMusic

</td>
</tr>
</table>

### Requirements

### Setup

### Testing

### Configuration




