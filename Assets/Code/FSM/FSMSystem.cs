using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSMSystem
{
    private List<FSMState> _fsmState = new List<FSMState>();

    /// <summary>
    /// 添加fsmstate状态机
    /// </summary>
    /// <param name="state">State.</param>
    public void AddFSMState(FSMState state)
    {
        // 做空判断检测
        if(_fsmState == null)
        {
            Debug.Log("FSM ERROR null");
        }
        if(_fsmState.Count == 0)
        {
            _fsmState.Add(state);
        }
        if (!_fsmState.Contains(state))
        {
            _fsmState.Add(state);
        }
    }

    /// <summary>
    /// 删除fsmstate状态机
    /// </summary>
    /// <param name="state">State.</param>
    public void DeleteFSMState(FSMState state)
    {
        if (_fsmState.Contains(state))
        {
            _fsmState.Remove(state);
        }
    }

    /// <summary>
    /// 设置当前状态机的状态
    /// </summary>
    /// <param name="fsmstate">Fsmstate.</param>
    /// <param name="state">State.</param>
    public void SetFSMState(FSMState fsmstate,State state)
    {
        if (_fsmState.Contains(fsmstate))
        {
            fsmstate.SetState(state);
        }
    }

    //public State GetFSMState(FSMState fsmstate)
    //{
    //    if (_fsmState.Contains(fsmstate))
    //    {
    //        return fsmstate.GetState();
    //    }
    //    return ;
    //}
}
