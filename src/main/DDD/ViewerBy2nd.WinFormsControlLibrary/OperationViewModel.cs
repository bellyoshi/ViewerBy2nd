using System;
using System.Collections.Generic;
using ViewerBy2ndLib;

public class OperationViewModel
{
    private Size bound;

    // FileList property is made private set to control its modification through the AddFile method
    public IList<FileViewParam> FileList { get; set; } = new List<FileViewParam>();

    // Event that is fired whenever a file is added
    public event Action? FileListChanged;

    public void AddFile(string file)
    {
        FileList.Add(new FileViewParam(file, bound));

        // Invoke the FileListChanged event whenever a file is added
        FileListChanged?.Invoke();
    }


}
