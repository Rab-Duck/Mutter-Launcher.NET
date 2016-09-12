' from http://bitdatasci.blogspot.jp/2015/10/windowsoszipwsh.html

option Explicit
dim objFSO, objFile, objShell, InputFile, ZipFile, hdrary, strbuf, ZipItemCount, i

if WScript.Arguments.Count < 2 then
    WScript.Echo "Usage: CScript.exe CompZip.VBS ZIPFile InputFiles..."
    WScript.Quit
end if

ZipFile=WScript.Arguments.Item(0)

WScript.Echo("zip start to " & ZipFile & " ...")


' Zip�t�@�C���V�K�쐬
hdrary = Array(80, 75, 5, 6, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)  'zip�t�@�C���̃w�b�_���
For i = 0 To UBound(hdrary)
  strbuf = strbuf & Chr(hdrary(i))
Next

' �t�@�C���V�K�쐬�i�����t�@�C���͏㏑�������j
Set objFSO = WScript.CreateObject("Scripting.FileSystemObject")
Set objFile = objFSO.CreateTextFile(ZipFile, True)
objFile.Write(strbuf)
objFile.Close
Set objFile = Nothing

' �V�K�쐬����Zip�t�@�C���ɁA���k���t�@�C����ǉ�
Set objShell = CreateObject("Shell.Application")
Set objFile = objShell.NameSpace(objFSO.GetAbsolutePathName(ZipFile))
ZipItemCount = objFile.Items().Count
for i = 1 to WScript.Arguments.Count - 1
    InputFile = WScript.Arguments.Item(i)

    WScript.Echo("... " & InputFile)

    If objFSO.FolderExists(InputFile) Or objFSO.FolderExists(InputFile) Then
        objFile.CopyHere(objFSO.GetAbsolutePathName(InputFile))

        ' �ǉ������҂�
        Do While ZipItemCount = objFile.Items().count
            WScript.Sleep(250)
        Loop
        If objFSO.FolderExists(InputFile) Then
          objFSO.DeleteFolder InputFile
        Else
          objFSO.DeleteFile InputFile
        End If
    Else
        WScript.Echo("not exist: " & InputFile)
    End if

    ZipItemCount = ZipItemCount + 1
    
next

Set objFSO = Nothing
Set objFile = Nothing
Set objShell = Nothing

WScript.Echo("... zip end")
