using System;
using System.Collections.Generic;
using System.Text;

namespace FindDupes2
{
    class Search:IDisposable
    {
        public Search(int minFileSize, string searchFolder)
        {
            FileBatchSize = 250;
            MinFileSize = minFileSize;
            FileEntries = new Dictionary<string, FileEntry>();
            SearchFolder = searchFolder;
        }

        //the master list of files we looked at >= MinFileSize
        public Dictionary<string, FileEntry> FileEntries
        {
            get;
            set;
        }

        public void Dispose()
        {
            FileEntries = null;
        }

        //count how many files we looked at in total (excluding ones we could not access due to permissions or locks)
        public int TotalFileCount
        {
            get;
            set;
        }

        //count how many directories we looked at in total (excluding ones we could not access due to permissions or locks)
        public int TotalDirectoryCount
        {
            get;
            set;
        }

        //how many duplicates found, not including first instance of file
        public int DuplicateFileCount
        {
            get;
            set;
        }

        //ignore files smaller than this size
        public int MinFileSize
        {
            get;
            set;
        }

        //how many to process before calling DoEvents
        int FileBatchSize
        {
            get;
            set;
        }

        //total amount of space we could reclaim the matching files
        public long PotentialSpaceSavingsBytes
        {
            get;
            set;
        }

        public string SearchFolder
        {
            get;
            set;
        }

        public int FileCountExceedingMinSize
        {
            get;
            set;
        }


    }
}
