# ChakramFF

[![Prod Pipeline ChakramFF](https://github.com/byakkoder/ChakramFF/actions/workflows/main.yml/badge.svg)](https://github.com/byakkoder/ChakramFF/actions/workflows/main.yml)

ChakramFF is a GUI software client for FFmpeg    

Copyright (C) 2021-present John García

This program is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with this program.  If not, see https://www.gnu.org/licenses/.


## Contribution

I made this software with the porpouse to show my programming skills and
to create a "simple to use" and modern GUI solution to process video files 
throught FFmpeg.

Currently, I don't want collaboration to evolve the source code of this 
software but maybe in the future I'll consider it.

Best regards and enjoy this software.

    
## About ChakramFF and FFmpeg
    
ChakramFF is a GUI for FFmpeg initially created to be an "easy to use" tool to
merge video files into a MKV file.
 
ChakramFF does not contain, include or link FFmpeg libraries, it only makes calls 
to FFmpeg tools (exe files) throught command line to process multimedia files. 
To download FFmpeg, please visit http://ffmpeg.org/

ChakramFF is not related to FFmpeg project. FFmpeg is a framework able to process 
multimedia files and it's licensed under GLP or LGPL. 
For more information visit http://ffmpeg.org/about.html

ChakramFF uses some third-party libraries with their own licenses. For more information
see the THIRD-PARTY-NOTICES.txt file.


## Dependencies

* .NET 8
* FFmpeg >= 4.2.3 (ffmpeg.exe is used to process video files, ffprobe.exe is used to get media info and ffplay is used to preview streams.)
* Microsoft Windows OS compatible with .NET 8 and FFmpeg >= 4.2.3


## How to start with ChakramFF

1. Go to http://ffmpeg.org/ to download FFmpeg.
2. Decompress FFmpeg zip in a directory.
3. Run the ChakramFF exe file.
4. Setup the path where the FFmpeg exe files are located.


## Features

* Merge media files into a MKV file.
* Input streams visualization and reordering.
* Add/Delete input streams (based on input files).
* Enable/Dissable input streams.
* Input streams preview.
* Input files playback.
* File/Stream metadata visualization.
* Stream settings edition (stream title, language, delay and set as default stream).
* Media info visualization of all file streams (file metadata).


## Compatibility

ChakramFF has been tested with FFmpeg version 4.2.3


## WARNING

This project is being upgraded from .NET Framework 4.7.2 to .NET 8, some issues may occur due to this upgrade process.


## Contact

* E-Mail: byakkoder@outlook.com
* Project Site: https://github.com/byakkoder/ChakramFF
