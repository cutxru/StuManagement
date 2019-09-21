using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WpfApplication7.View;
using WpfApplication7;
using System.Collections.Generic;

namespace WpfApplication7.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        //private string title;

        //public string Title
        //{
        //    get { return title; }
        //    set { Set(ref title, value); }
        //}

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            ////if (IsInDesignMode)
            ////{
            ////    // Code runs in Blend --> create design time data.
            ////}
            ////else
            ////{
            ////    // Code runs "for real"
            ////}
            //Show = new RelayCommand(() => ShowExecute(), () => true);

            AddStudent = new RelayCommand(() => AddStudentExecute(), () => true);
            AddClass = new RelayCommand(() => AddClassExecute(), () => true);
            Delete = new RelayCommand(() => DeleteExecute(), () => true);
            Update = new RelayCommand(() => UpdateExecute(), () => true);
            ComboBox_SelectionChanged = new RelayCommand(() => ComboBox_SelectionChangedExecute(), () => true);
            InitialDataBase();//datagrid数据
            InitialList();
            InitialComboList();//下拉框数据
            //InitialComboBaseList();
        }

        

        private StudentEntity _studentEntity;
        public StudentEntity SelectStudentEntity
        {
            get { return _studentEntity; }
            set
            {
                Set(ref _studentEntity, value);
            }
        }

        public ICommand Delete { get; set; }
        /// <summary>
        /// 删除选中的学生
        /// </summary>
        private void DeleteExecute()
        {
            MessageBoxResult messageBoxResult = MessageBox.Show("确定要删除吗", "提示", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            if (messageBoxResult == MessageBoxResult.OK)
            {
                using (var db = new StudentData())
                {
                    //不可行
                    //db.StudentEntities.Remove(SelectStudentEntity);
                    //db.SaveChanges();

                    //此处要根据选中项的主键删除选中项
                    var item = db.StudentEntities.SingleOrDefault(l => l.Stu_id == SelectStudentEntity.Stu_id);
                    if (item != null)
                    {
                        db.StudentEntities.Remove(item);
                        db.SaveChanges();
                        MessageBox.Show("删除成功");
                        InitialList();
                    }
                }
            }
        }

        public ICommand Update { get; set; }
        /// <summary>
        /// 修改信息
        /// </summary>
        private void UpdateExecute()
        {
            using (var db=new StudentData())
            {
                var id = db.StudentEntities.Find(SelectStudentEntity.Stu_id);//根据选中项的主键获取实体对象数据
                if (id != null)
                {
                    var entry = db.Entry(id);//获取给定对象
                    entry.CurrentValues.SetValues(SelectStudentEntity);//根据给定对象中读取到的属性值设定

                    var cl = db.ClassEntities.SingleOrDefault(a => a.Stu_class == SelectStudentEntity.Stu_class);
                    if (cl == null)//班级列表不存在此班级
                    {
                        MessageBoxResult messageBoxResult = MessageBox.Show("此班级不存在,要添加到班级列表吗", "提示", MessageBoxButton.OKCancel, MessageBoxImage.Question);
                        if (messageBoxResult == MessageBoxResult.OK)//添加到班级列表
                        {
                            ClassEntity classEntity = new ClassEntity();
                            classEntity.Stu_class = SelectStudentEntity.Stu_class;
                            db.ClassEntities.Add(classEntity);
                            db.SaveChanges();
                            MessageBox.Show("修改成功");
                            InitialList();
                            InitialComboList();
                        }
                        else
                        {
                            InitialList();
                        }
                    }
                    else
                    {
                        db.SaveChanges();
                        MessageBox.Show("修改成功");
                    }
                }
            }
        }

        public RelayCommand ComboBox_SelectionChanged { get; set; }
        public void ComboBox_SelectionChangedExecute()
        {
            
            var selectList = dataBaseList.Where(a => a.Stu_class == Selected.Stu_class).ToList();
            list.Clear();
            foreach (var item in selectList)
            {
                
                list.Add(new StudentEntity()
                {
                    Stu_age = item.Stu_age,
                    Stu_class = item.Stu_class,
                    Stu_gender = item.Stu_gender,
                    Stu_id = item.Stu_id,
                    Stu_name = item.Stu_name
                });
            }
        }
        /// <summary>
        /// 弹出添加学生的窗口
        /// </summary>
        public ICommand AddStudent { get; set; }
        private void AddStudentExecute()
        {
            AddStudentView addStudentView = new AddStudentView();
            var flag = addStudentView.ShowDialog();
            if(flag==false)
            {
                InitialList();
                
            }
        }

        /// <summary>
        /// 弹出添加班级的窗口
        /// </summary>
        public ICommand AddClass { get; set; }
        private void AddClassExecute()
        {
            AddClassView addClassView = new AddClassView();
            var flag = addClassView.ShowDialog();
            if(flag==false)
            {
                InitialList();
                InitialComboList();
            }
        }

        
        #region 加载数据
        public ObservableCollection<StudentEntity> list { get; set; } = new ObservableCollection<StudentEntity>();//保存要展示在界面的数据
        //List
        public ObservableCollection<StudentEntity> dataBaseList { get; set; } = new ObservableCollection<StudentEntity>();//保存从数据库里面拿到的数据
        //public DataGrid dataGrid;
        /// <summary>
        /// 绑定数据
        /// </summary>
        public void InitialList()
        {
            list.Clear();
            using (var db=new StudentData())
            {
                var info = db.StudentEntities.ToList();
                if (info != null)
                {
                    foreach (var item in info)
                    {
                        list.Add(new StudentEntity() {
                            Stu_id = item.Stu_id,
                            Stu_name = item.Stu_name,
                            Stu_class = item.Stu_class,
                            Stu_age = item.Stu_age,
                            Stu_gender = item.Stu_gender
                        });
                    }
                }
            }
        }

        /// <summary>
        /// 从数据库里面查数据
        /// </summary>
        public void InitialDataBase()
        {
            dataBaseList.Clear();
            using (var db = new StudentData())
            {
                var info = db.StudentEntities.ToList();
                if (info != null)
                {
                    foreach (var item in info)
                    {
                        dataBaseList.Add(new StudentEntity()
                        {
                            Stu_id = item.Stu_id,
                            Stu_name = item.Stu_name,
                            Stu_class = item.Stu_class,
                            Stu_age = item.Stu_age,
                            Stu_gender = item.Stu_gender
                        });
                    }
                }
            }
        }

        //public void DataGrid_Loaded(object sender, RoutedEventArgs e)
        //{
        //    dataGrid = sender as DataGrid;
        //}
        #endregion


        #region  把班级名称显示到下拉框
        public ObservableCollection<ClassEntity> comboList { get; set; } = new ObservableCollection<ClassEntity>();
        public ObservableCollection<ClassEntity> comboBaseList { get; set; } = new ObservableCollection<ClassEntity>();
        
        public void InitialComboList()
        {
            comboList.Clear();
            using (var db = new StudentData())
            {
                var info = db.ClassEntities.ToList();
                if (info != null)
                {
                    foreach (var item in info)
                    {
                        comboList.Add(new ClassEntity() {
                            Stu_class=item.Stu_class,
                            Class_id=item.Class_id
                        });
                    }
                }
            }
        }
        public void InitialComboBaseList()
        {
            comboBaseList.Clear();
            using (var db = new StudentData())
            {
                comboBaseList.Clear();
                var info = db.ClassEntities.ToList();
                if (info != null)
                {
                    foreach (var item in info)
                    {
                        comboBaseList.Add(new ClassEntity()
                        {
                            Stu_class = item.Stu_class,
                            Class_id = item.Class_id
                        });
                    }
                }
            }
        }
        #endregion

        #region 根据下拉框选中的值在datagrid中显示数据
        private ClassEntity selected;
        public ClassEntity Selected
        {
            get { return selected; }
            set
            {
                Set(ref selected, value);
            }
        }

        //private string stu_class;
        //public string Stu_class
        //{
        //    get { return stu_class; }
        //    set
        //    {
        //        //Set(ref stu_class, value);
        //        stu_class = value;
        //        RaisePropertyChanged(() => stu_class);
        //    }
        //}

        //private int class_id;
        //public int Class_id
        //{
        //    get { return class_id; }
        //    set
        //    {
        //        //Set(ref class_id, value);
        //        class_id = value;
        //        RaisePropertyChanged(() => class_id);
        //    }
        //}
        public void SelectList()
        {
            var selectList = list.Where(a => a.Stu_class == Selected.Stu_class).ToList();
            list.Clear();
            foreach (var item in selectList)
            {
                list.Add(new StudentEntity()
                {
                    Stu_age = item.Stu_age,
                    Stu_class = item.Stu_class,
                    Stu_gender = item.Stu_gender,
                    Stu_id = item.Stu_id,
                    Stu_name = item.Stu_name
                });
            }
        }

        #endregion


        
        
    }
}