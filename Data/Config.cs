﻿#region LICENSE

// Copyright 2014 LeagueSharp.Loader
// Config.cs is part of LeagueSharp.Loader.
// 
// LeagueSharp.Loader is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// LeagueSharp.Loader is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with LeagueSharp.Loader. If not, see <http://www.gnu.org/licenses/>.

#endregion

namespace LeagueSharp.Loader.Data
{
    #region

    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.IO;
    using System.Runtime.CompilerServices;
    using System.Windows;
    using System.Windows.Input;
    using System.Xml.Serialization;
    using LeagueSharp.Loader.Class;

    #endregion

    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "", IsNullable = false)]
    public class Config : INotifyPropertyChanged
    {
        [XmlIgnore] public static Config Instance;
        private bool _firstRun = true;
        private Hotkeys _hotkeys;

        private bool _install = true;
        private ObservableCollection<string> _knownRepositories;
        private string _leagueOfLegendsExePath;
        private ObservableCollection<Profile> _profiles;
        private string _selectedLanguage;
        private Profile _selectedProfile;
        private ConfigSettings _settings;
        private bool _showDevOptions;
        private bool _updateOnLoad;
        private bool _tosAccepted;
        private string _appDirectory;
        private string _selectedColor;

        private double _columnCheckWidth = 20;
        private double _columnNameWidth = 150;
        private double _columnTypeWidth = 75;
        private double _columnVersionWidth = 90;
        private double _columnLocationWidth = 180;

        private double windowTop = 150;

        private double windowLeft = 150;

        private double windowWidth = 800;

        private double windowHeight = 450;

        private WindowState windowState;

        public string RandomName { get; set; }

        public double ColumnCheckWidth
        {
            get { return _columnCheckWidth; }
            set
            {
                _columnCheckWidth = value;
                OnPropertyChanged();
            }
        }

        public double ColumnNameWidth
        {
            get { return _columnNameWidth; }
            set
            {
                _columnNameWidth = value;
                OnPropertyChanged();
            }
        }

        public double ColumnTypeWidth
        {
            get { return _columnTypeWidth; }
            set
            {
                _columnTypeWidth = value;
                OnPropertyChanged();
            }
        }

        public double ColumnVersionWidth
        {
            get { return _columnVersionWidth; }
            set
            {
                _columnVersionWidth = value;
                OnPropertyChanged();
            }
        }

        public double ColumnLocationWidth
        {
            get { return _columnLocationWidth; }
            set
            {
                _columnLocationWidth = value;
                OnPropertyChanged();
            }
        }

        public string SelectedColor
        {
            get { return _selectedColor; }
            set
            {
                _selectedColor = value;
                OnPropertyChanged();
            }
        }

        public string AppDirectory
        {
            get { return _appDirectory; }
            set
            {
                _appDirectory = value;
                OnPropertyChanged();
            }
        }

        public bool TosAccepted
        {
            get { return _tosAccepted; }
            set
            {
                _tosAccepted = value;
                OnPropertyChanged();
            }
        }

        public string SelectedLanguage
        {
            get { return _selectedLanguage; }
            set
            {
                _selectedLanguage = value;
                OnPropertyChanged();
            }
        }

        public string LeagueOfLegendsExePath
        {
            get { return _leagueOfLegendsExePath; }
            set
            {
                _leagueOfLegendsExePath = value;
                OnPropertyChanged();
            }
        }

        public bool FirstRun
        {
            get { return _firstRun; }
            set
            {
                _firstRun = value;
                OnPropertyChanged();
            }
        }

        public bool ShowDevOptions
        {
            get { return _showDevOptions; }
            set
            {
                _showDevOptions = value;
                OnPropertyChanged();
            }
        }

        public bool Install
        {
            get { return _install; }
            set
            {
                _install = value;
                OnPropertyChanged();
            }
        }

        public bool UpdateOnLoad
        {
            get { return _updateOnLoad; }
            set
            {
                _updateOnLoad = value;
                OnPropertyChanged();
            }
        }

        public string Username { get; set; }

        public string Password { get; set; }

        public ConfigSettings Settings
        {
            get { return _settings; }
            set
            {
                _settings = value;
                OnPropertyChanged();
            }
        }

        public Hotkeys Hotkeys
        {
            get { return _hotkeys; }
            set
            {
                _hotkeys = value;
                OnPropertyChanged();
            }
        }

        public Profile SelectedProfile
        {
            get { return _selectedProfile; }
            set
            {
                _selectedProfile = value;
                OnPropertyChanged();
            }
        }

        [XmlArrayItem("Profiles", IsNullable = true)]
        public ObservableCollection<Profile> Profiles
        {
            get { return _profiles; }
            set
            {
                _profiles = value;
                OnPropertyChanged();
            }
        }

        [XmlArrayItem("KnownRepositories", IsNullable = true)]
        public ObservableCollection<string> KnownRepositories
        {
            get { return _knownRepositories; }
            set
            {
                _knownRepositories = value;
                OnPropertyChanged();
            }
        }

        public double WindowTop
        {
            get
            {
                return this.windowTop;
            }
            set
            {
                this.windowTop = value;
                OnPropertyChanged();
            }
        }

        public double WindowLeft
        {
            get
            {
                return this.windowLeft;
            }
            set
            {
                this.windowLeft = value;
                OnPropertyChanged();
            }
        }

        public double WindowWidth
        {
            get
            {
                return this.windowWidth;
            }
            set
            {
                this.windowWidth = value;
                OnPropertyChanged();
            }
        }

        public double WindowHeight
        {
            get
            {
                return this.windowHeight;
            }
            set
            {
                this.windowHeight = value;
                OnPropertyChanged();
            }
        }

        public WindowState WindowState
        {
            get
            {
                return this.windowState;
            }
            set
            {
                this.windowState = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }


    [XmlType(AnonymousType = true)]
    public class ConfigSettings : INotifyPropertyChanged
    {
        private ObservableCollection<GameSettings> _gameSettings;

        [XmlArrayItem("GameSettings", IsNullable = true)]
        public ObservableCollection<GameSettings> GameSettings
        {
            get { return _gameSettings; }
            set
            {
                _gameSettings = value;
                OnPropertyChanged("GameSettings");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

    public class GameSettings : INotifyPropertyChanged
    {
        private string _name;

        private List<string> _posibleValues;
        private string _selectedValue;

        [XmlIgnore]
        public string DisplayName
        {
            get { return Utility.GetMultiLanguageText(_name); }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }

        public List<string> PosibleValues
        {
            get { return _posibleValues; }
            set
            {
                _posibleValues = value;
                OnPropertyChanged("PosibleValues");
            }
        }

        public string SelectedValue
        {
            get { return _selectedValue; }
            set
            {
                _selectedValue = value;
                OnPropertyChanged("SelectedValue");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

    [XmlType(AnonymousType = true)]
    public class Hotkeys : INotifyPropertyChanged
    {
        private ObservableCollection<HotkeyEntry> _selectedHotkeys;

        [XmlArrayItem("SelectedHotkeys", IsNullable = true)]
        public ObservableCollection<HotkeyEntry> SelectedHotkeys
        {
            get { return _selectedHotkeys; }
            set
            {
                _selectedHotkeys = value;
                OnPropertyChanged("Hotkeys");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

    public class HotkeyEntry : INotifyPropertyChanged
    {
        private Key _hotkey;
        private string _name;

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }

        public string DisplayDescription
        {
            get { return Utility.GetMultiLanguageText(Description); }
        }

        public string Description { get; set; }

        public Key Hotkey
        {
            get { return _hotkey; }
            set
            {
                _hotkey = value;
                OnPropertyChanged("Hotkey");
                OnPropertyChanged("HotkeyString");
            }
        }

        public byte HotkeyInt
        {
            get
            {
                if (Hotkey == Key.LeftShift || Hotkey == Key.RightShift)
                {
                    return 16;
                }

                if (Hotkey == Key.LeftAlt || Hotkey == Key.RightAlt)
                {
                    return 0x12;
                }

                if (Hotkey == Key.LeftCtrl || Hotkey == Key.RightCtrl)
                {
                    return 0x11;
                }

                return (byte) KeyInterop.VirtualKeyFromKey(Hotkey);
            }
            set { }
        }

        public string HotkeyString
        {
            get { return _hotkey.ToString(); }
        }

        public Key DefaultKey { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}