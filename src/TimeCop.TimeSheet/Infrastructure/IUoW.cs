﻿namespace TimeCop.TimeSheet.Infrastructure
{
    public interface IUoW
    {
        void CommitChange();
    }
}