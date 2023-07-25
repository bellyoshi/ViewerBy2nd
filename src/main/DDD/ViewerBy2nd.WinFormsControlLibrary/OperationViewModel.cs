using System;
using System.Collections.Generic;
using System.Reflection;
using ViewerBy2ndLib;

public class OperationViewModel
{
    private Size bound;

    // FileList property is made private set to control its modification through the AddFile method
    public IList<FileViewParam> FileList { get; set; } = new List<FileViewParam>();
    private int _selectedIndex = -1;
    public int SelectedIndex
    {
        get => _selectedIndex;
        set
        {
            _selectedIndex = value;
            SelectedIndexChanged?.Invoke();
        }
    }
    public void SelectFileViewParam(FileViewParam fileViewParam)
    {
        for (int i = 0; i < FileList.Count; i++)
        {
            if (FileList[i] == fileViewParam)
            {
                SelectedIndex = i;
                return;
            }
        }
    }

    // Event that is fired whenever a file is added
    public event Action? FileListChanged;

    public event Action? SelectedIndexChanged;


    public void Initialize(IEnumerable<FileViewParam> files)
    {
        foreach (var file in files)
        {
            FileList.Add(file);
        }
    }

    public void AddFiles(IEnumerable<string> files)
    {
        foreach (var file in files)
        {
            FileList.Add(new FileViewParam(file, bound));
        }
        FileListChanged?.Invoke();
    }

    internal void DeleteFiles(List<FileViewParam> list)
    {
        foreach (var file in list)
        {
            FileList.Remove(file);
        }
        FileListChanged?.Invoke();
    }
}
