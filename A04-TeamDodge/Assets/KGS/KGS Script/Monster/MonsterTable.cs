using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterTable
{

    //싱글톤 패턴을 적용합니다.
    private MonsterTable() { CreateTable(); }

    private static MonsterTable I = new MonsterTable();

    public static MonsterTable Instance => I;
    //////////////////////////////////////////

    public struct DATA
    {
        
        public int      identifier;
        public string   name;
        public int      hp;

        public DATA(int identifier, string name, int hp)
        {
            this.identifier    = identifier;
            this.name          = name;
            this.hp            = hp;
        }

    }

    
    public DATA Find(int identifier)
    {
        return m_dataList[identifier];
    }


    /// <summary>
    /// 테이블을 생성합니다.
    /// </summary>
    private void CreateTable()
    {

        m_dataList.Add(new DATA(0, "Moving man", 2));
        m_dataList.Add(new DATA(1, "Curve moving man", 2));
        m_dataList.Add(new DATA(2, "Shot moving man", 5));

    }

    private List<DATA> m_dataList = new List<DATA>();

}
