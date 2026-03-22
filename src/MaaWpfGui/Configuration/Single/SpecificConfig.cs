// <copyright file="SpecificConfig.cs" company="MaaAssistantArknights">
// Part of the MaaWpfGui project, maintained by the MaaAssistantArknights team (Maa Team)
// Copyright (C) 2021-2025 MaaAssistantArknights Contributors
//
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU Affero General Public License v3.0 only as published by
// the Free Software Foundation, either version 3 of the License, or
// any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY
// </copyright>
#nullable enable
using System.ComponentModel;
using System.Text.Json.Serialization;
using JetBrains.Annotations;
using MaaWpfGui.Configuration.Factory;
using MaaWpfGui.Configuration.Single.MaaTask;
using MaaWpfGui.Helper;
using ObservableCollections;

namespace MaaWpfGui.Configuration.Single;

public class SpecificConfig : INotifyPropertyChanged, IJsonOnDeserialized
{
    public event PropertyChangedEventHandler? PropertyChanged;

    public SpecificConfig()
    {
        EnsureDefaultTaskQueue();
    }

    [JsonInclude]
    public ObservableDictionary<string, int> InfrastOrder { get; private set; } = [];

    [JsonInclude]
    public ObservableList<BaseTask> TaskQueue { get; private set; } = [];

    [JsonInclude]
    public int TaskSelectedIndex { get; set; } = -1;

    [JsonInclude]
    public ObservableDictionary<string, bool> DragItemIsChecked { get; private set; } = [];

    [UsedImplicitly]
    public void OnPropertyChanged(string propertyName, object before, object after)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventDetailArgs(propertyName, before, after));
    }

    private void EnsureDefaultTaskQueue()
    {
        if (TaskQueue.Count > 0)
        {
            return;
        }

        TaskQueue.Add(new StartUpTask { Name = LocalizationHelper.GetString("StartUp") });
        TaskQueue.Add(new FightTask { Name = LocalizationHelper.GetString("Fight") });
        TaskQueue.Add(new InfrastTask { Name = LocalizationHelper.GetString("Infrast") });
        TaskQueue.Add(new RecruitTask { Name = LocalizationHelper.GetString("Recruit") });
        TaskQueue.Add(new MallTask { Name = LocalizationHelper.GetString("Mall") });
        TaskQueue.Add(new AwardTask { Name = LocalizationHelper.GetString("Award") });
        TaskQueue.Add(new RoguelikeTask { Name = LocalizationHelper.GetString("Roguelike") });
        TaskQueue.Add(new ReclamationTask { Name = LocalizationHelper.GetString("Reclamation") });
        TaskQueue.Add(new UserDataUpdateTask { Name = LocalizationHelper.GetString("UserDataUpdate") });
    }

    public void OnDeserialized()
    {
        EnsureDefaultTaskQueue();
    }
}
