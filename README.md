# finddupes

A Windows GUI utility for finding an optionally deleting duplicate files.

![image](https://github.com/drittich/finddupes2/assets/1222810/73bdf3b6-dc07-4331-b265-0ecdfc6765ef)

## Installation

This relies on the [.NET Desktop Runtime](https://dotnet.microsoft.com/en-us/download/dotnet/8.0) so you may need to install that first.

## Usage

Choose your Source folder and hit go. As it searches it will display a running count of duplicate files and when it is complete the file listings will be shown. 
You can select one or more files and click the **Delete Selected Files** button to remove them. You can also Cancel the run at any time and it will then show the duplicate files found up to that point.

File comparison are doing using MD5 hashes, and if you select **Also Match Names** the file name must match too.
