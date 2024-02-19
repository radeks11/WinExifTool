# WinExifTool

WinExifTool is a graphical interface for changing data in media files. All reads and changes are saved in batch files. 
The generated files are stored ExecLog placed as a subdirectory located in the directory where WinExifTool was installed. 

Main features of the program:
 - Group change of selected IPTC and XMP metadata.
 - Preview of Exif, IPTC, XMP data (and all others read by ExifTool)
 - Manual geolocation by selecting from a map
 - Geolocalization based on GPX path  
 - Two kinds of map: Google Street Map and Touristic Map by Mapy.cz
 - Tools:
    - Date generation including offset
    - Move/copy data between fields
    - Change create and modify time based on name of file
    - Change create and modify time based on Exif date

### Before start using WinExifTool

Please notice mass editing is conducted on tagged, not selected files. It can be confusing at the begining. 

1. Download ExifTool.exe and place somewere in the filesystem. Select the ExifTool when you first time run the program. You can change the path to ExifTool in Configuration form.
https://exiftool.org/

2. Consider generation of Google Map API Key. Google Map API Key is required to geocoding and finding locations by name.
https://developers.google.com/maps/documentation/embed/get-api-key?hl=pl

### Known issues

Most important issue are special characters in filenames. See following link to resolve UTF-8 filenaming.
https://stackoverflow.com/questions/57131654/using-utf-8-encoding-chcp-65001-in-command-prompt-windows-powershell-window/57134096#57134096

Filtering is still under development as well as geocoding. Stay tuned.

### Credits

Phil Harvey ofcourse for creating wonderfull ExifTool. See:
https://github.com/exiftool/exiftool

GMap.NET - Maps For Windows
https://github.com/judero01col/GMap.NET

Icons used in the project:
https://www.iconfinder.com/search/icons?family=phosphor-fill

