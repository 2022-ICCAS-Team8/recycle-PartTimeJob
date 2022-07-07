using UnityEngine;
using System.IO;
using System;

public class BackEndGameLog : MonoBehaviour
{
  static public string s_LogPath = "";
  
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
  public static void SetLogPath(){
    string t_Directory = "/Log";
    string t_FileName = "Log.txt";
    string t_Path = "";

    t_Path = (Application.dataPath + t_Directory);
    s_LogPath = (Application.dataPath + t_Directory + "/" + t_FileName);
    if (!Directory.Exists(t_Path))
    {
      Directory.CreateDirectory(t_Path);
    }
  }
public static void Log(string _logmsg)
    {
        // 시스템 로그도 기록
        Debug.Log(_logmsg);

        // 파일 경로가 만들어지지 않은 상태라면 파일경로 생성 함수(메소드)로 생성
        if (s_LogPath == "")
        {
            SetLogPath();
        }

        FileStream t_File = null;

        // 파일 확인하고 없다면 파일을 생성
        if (!File.Exists(s_LogPath))
        {
            //File.Create(s_LogPath);
            t_File = new FileStream(s_LogPath, FileMode.Create, FileAccess.Write);
        }
        // 파일이 있드면 내용 추가 형식으로 열기
        else
        {
            t_File = new FileStream(s_LogPath, FileMode.Append);
        }
        
        // 열린 파일이 크기이 크다면 닫고 새 파일스트림으로 생성
        if (t_File.Length > 1048000)
        {
            t_File.Close();
            t_File = new FileStream(s_LogPath, FileMode.Create, FileAccess.Write);
        }

        StreamWriter t_SW = new StreamWriter(t_File);

        // 로그 내용 앞에 시간 추가 
        string t_Logfrm = DateTime.Now.ToString("mm-dd hh:mm:ss") + " -- " + _logmsg;

        // 로그 기록
        t_SW.WriteLine(t_Logfrm);

        // 사용했던 스트림들 닫기
        t_SW.Close();
        t_File.Close();
  }
}
