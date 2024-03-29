# finddupes

A Windows GUI utility for finding and optionally deleting duplicate files.

![image](https://github.com/drittich/finddupes2/assets/1222810/73bdf3b6-dc07-4331-b265-0ecdfc6765ef)

## Download

Go to the [latest releases](https://github.com/drittich/finddupes2/releases/latest) and download the correct version for your operating system (probably the x64 one).

## Installation

>**Note:** This application relies on the [.NET Desktop Runtime](https://dotnet.microsoft.com/en-us/download/dotnet/8.0) so you may need to install that first.

Once you have downloaded the release, unzip the file to a folder of your choice, and then run the executable. If you need an application that can handle .7z files, you can use [7-zip](https://www.7-zip.org/download.html)

## Usage

Choose your **Source** folder and hit go. As it searches it will display a running count of duplicate files and when it is complete the file listings will be shown. 
You can select one or more files and click the **Delete Selected Files** button to remove them. You can also **Cancel** the run at any time and it will then show the duplicate files found up to that point.

File comparison are doing using MD5 hashes, and if you select **Also Match Names** the file name must match too.
