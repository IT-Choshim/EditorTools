//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Game.Data.Skill
{
    using System;
    using System.Collections.Generic;
    
    
    public class Skill
    {
        
        // 技能

		public double Id {get;set;}

        // 描述
		public string Des {get;set;}
        // 使用类型
		public double UseType {get;set;}
        // 包含的技能块
		public List<double> SkillBlocks {get;set;}
        // 等级id
		public double LevelID {get;set;}
        // 消耗
		public double Consume {get;set;}
        // 图标
		public string Icon {get;set;}
    }
}
