using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Collections.Specialized;

namespace Controls
{     

     #region �ÿؼ���Ҫ�õ���ö������

    public enum PreViewPosition
    {
        Top,
        Left,
        Right,
        Bottom
    }

    public enum WatermarkType
    {
        None,
        Image,
        Text
    }

    public enum WatermarkPosition
    {
        TopLeft,
        TopCenter,
        TopRight,
        MiddleLeft,
        MiddleCenter,
        MiddleRight,
        BottomLeft,
        BottomCenter,
        BottomRight
    }

    public enum Rename
    {
        NotSet,
        Guid,
        DateTime
    }
    #endregion
    public class ImageUploader : WebControl, INamingContainer, IPostBackDataHandler, IDisposable
    {
        #region ����

        #region JS

        private const string FILE_UPLOAD_SCRIPT =
@"<script language='javascript'>
function PreView(ImageSelector, PreViewControl, PreviewImageUrl)
{
    if(ImageSelector.value == '')
    {
        PreViewControl.src = PreviewImageUrl;
    }
    else
    {
        PreViewControl.src = ImageSelector.value;
    }
}
</script>";

        private const string FILE_UPLOAD_SCRIPT_ID = "3116a486-11e0-4197-b3aa-b7707cc08129";
        private const string FILE_UPLOAD_HOOK = "PreView({0}, {1}, {2});";

        #endregion

        #region �ؼ�����
        FileUpload _fileUpload = null;
        Button _btnSave = null;
        HtmlImage _imgPreView = null;
        #endregion

        #region ��ֵ����

        #endregion

        #region ��ۿ��Ʊ���
        /// <summary>
        /// �ϴ���ť���ı�
        /// </summary>
        private string _strButtonSaveText = "�ϴ�";
        /// <summary>
        /// �ϴ���ť��CSS��ʽ
        /// </summary>
        private string _strButtonSaveCSSClass = string.Empty;
        /// <summary>
        /// �Ƿ���ʾͼƬԤ��
        /// </summary>
        private bool _bIsShowPreView = true;
        /// <summary>
        /// ͼƬԤ����λ��
        /// </summary>
        private PreViewPosition _enumPreViewPosition = PreViewPosition.Bottom;
        /// <summary>
        /// ͼƬԤ����CSS��ʽ
        /// </summary>
        private string _strPreViewCSSClass = string.Empty;
        /// <summary>
        /// Ĭ��ͼƬԤ��λ�õ�ռλͼƬ
        /// </summary>
        private string _strPreViewImageUrl = "./ZYT_Client/Styles/Default/Images/PreView.gif";
        #endregion

        #region ��������
        string _strPicSavePath = "../UploadFiles/Images/";
        string _strPicSavedName = string.Empty;
        string _strPicSavedPath = string.Empty;

        string _strPicThumbSavePath = "../UploadFiles/Images/Thumb/";
        string _strPicThumbSavedPath = string.Empty;
        string _strPicThumbSavedName = string.Empty;

        string _strAllowType = ".jpg|.gif|.png|.bmp";
        int _iMaxSize = 2048;//��λΪKB

        WatermarkType _enumWatermarkType = WatermarkType.None;
        string _strWatermarkText = "";
        System.Drawing.Font _fontWatermarkFont = new System.Drawing.Font("Arial", 12, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);//ˮӡ��������
        System.Drawing.Color _fontWatermarkColor = System.Drawing.Color.Black;
        string _strWatermarkImage = "./ZYT_Client/Styles/Default/Images/Watermark.png";
        byte _btWatermarkTransparency = 255;//ˮӡ͸����
        WatermarkPosition _enumWatermarkPosition = WatermarkPosition.BottomRight;//ˮӡλ��

        bool _bIsGenerateThumb = false;//�Ƿ��������ͼ
        int _iThumbMaxWidth = 400;//����ͼ�������
        int _iThumbMaxHeight = 300;//����ͼ�����߶�

        bool _bIsRename = true;//�Ƿ�������
        Rename _enumRenameType = Rename.DateTime;//��������ʽ

        string _strSuccessfulText = "�ɹ��ϴ�һ��ͼƬ��";
        bool _bIsAllowMulti = true;//�Ƿ���������ϴ�
        #endregion

        #endregion

        #region ����
        [Description("���水ť���ı�"), DefaultValue("�ϴ�")]
        public string SaveButtonText
        {
            get { return _strButtonSaveText; }
            set { _strButtonSaveText = value; }
        }

        [Description("���水ť��CSS��ʽ"), DefaultValue("")]
        public string SaveButtonCSSClass
        {
            get { return _strButtonSaveCSSClass; }
            set { _strButtonSaveCSSClass = value; }
        }

        [Description("�Ƿ���ʾԤ��"), DefaultValue(true)]
        public bool IsShowPreView
        {
            get { return _bIsShowPreView; }
            set { _bIsShowPreView = value; }
        }

        [Description("Ԥ��ͼƬ��λ��"), DefaultValue(PreViewPosition.Bottom)]
        public PreViewPosition PreviewProsition
        {
            get { return _enumPreViewPosition; }
            set { _enumPreViewPosition = value; }
        }

        [Description("ͼƬԤ����CSS��ʽ"), DefaultValue("")]
        public string PreViewCSSClass
        {
            set { _strPreViewCSSClass = value; }
            get { return _strPreViewCSSClass; }
        }

        [Description("Ԥ��ͼƬ��ռλͼƬURL"), DefaultValue("./ZYT_Client/Styles/Default/Images/PreView.gif")]
        public string DefaultPreviewImageURL
        {
            get { return _strPreViewImageUrl; }
            set { _strPreViewImageUrl = value; }
        }

        [Description("ͼƬ�ı���·�������·������ʽ��~/UploadFiles/Images/��"), DefaultValue("~/UploadFiles/Images/")]
        public string PicSavePath
        {
            set
            {
                _strPicSavePath = value;
                if (!_strPicSavePath.EndsWith("/"))
                {
                    _strPicSavePath += "/";
                }
            }
            get { return _strPicSavePath; }
        }

        [Description("����ͼ�ı���·�������·������ʽ��~/UploadFiles/Images/��"), DefaultValue("~/UploadFiles/Images/Thumb/")]
        public string PicThumbSavePath
        {
            set
            {
                _strPicThumbSavePath = value;
                if (!_strPicThumbSavedName.EndsWith("/"))
                {
                    _strPicThumbSavedPath += "/";
                }
            }
            get { return _strPicThumbSavePath; }
        }
        [Description("ֻ����ԭͼ����������"), Browsable(false)]
        public string PicSavedName
        {
            get { return _strPicSavedName; }
        }

        [Description("ֻ��������ͼ����������"), Browsable(false)]
        public string PicThumbSavedName
        {
            get { return _strPicThumbSavedName; }
        }

        [Description("ֻ����ԭͼ�ı���·�������ظ�ʽ���£�~/UploadFiles/Images/20061007143725222.jpg��"), Browsable(false)]
        public string PicSavedPath
        {
            get { return _strPicSavedPath; }
        }

        [Description("ֻ��������ͼ�����·�������·������ʽ��~/UploadFiles/Images/thumb_20061007143725222.jpg��"), Browsable(false)]
        public string PicThumbSavedPath
        {
            get { return _strPicThumbSavedPath; }
        }

        [Description("��ȡ�����������ϴ���ͼƬ���͵���չ������ʽ��.jpg|.gif|.bmp��"), DefaultValue(".jpg|.gif|.bmp|.png")]
        public string AllowPicType
        {
            set { _strAllowType = value; }
            get { return _strAllowType; }
        }

        [Description("��ȡ�����������ϴ���ͼƬ��С(KB)"), DefaultValue(2048)]
        public int MaxSize
        {
            get
            {
                return _iMaxSize;
            }
            set
            {
                if (value <= 0)
                {
                    _iMaxSize = 0;
                }
                else
                {
                    try
                    {
                        _iMaxSize = value;
                    }
                    catch
                    {
                        _iMaxSize = int.MaxValue;
                    }
                }
            }
        }

        [Description("��ȡ������ˮӡ����"), DefaultValue(WatermarkType.None)]
        public WatermarkType WatermarkType
        {
            get { return _enumWatermarkType; }
            set { _enumWatermarkType = value; }
        }

        [Description("��ȡ������ˮӡ����"), DefaultValue("")]
        public string WatermarkText
        {
            get { return _strWatermarkText; }
            set { _strWatermarkText = value; }
        }

        [Description("��ȡ������ˮӡ���ֵ�����")]
        public System.Drawing.Font WatermarkTextFont
        {
            get { return _fontWatermarkFont; }
            set { _fontWatermarkFont = value; }
        }

        [Description("��ȡ������ˮӡ���ֵ���ɫ")]
        public System.Drawing.Color WatermarkTextColor
        {
            get { return _fontWatermarkColor; }
            set { _fontWatermarkColor = value; }
        }

        [Description("��ȡ������ˮӡͼƬ��ַ"), DefaultValue("./ZYT_Client/Styles/Default/Images/Watermark.png")]
        public string WatermarkImage
        {
            get { return _strWatermarkImage; }
            set { _strWatermarkImage = value; }
        }

        [Description("��ȡ������ˮӡ��͸����"), DefaultValue(255)]
        public byte WatermarkTransparency
        {
            get { return _btWatermarkTransparency; }
            set
            {
                _btWatermarkTransparency = value;
            }
        }

        [Description("��ȡ������ˮӡ��λ��"), DefaultValue(WatermarkPosition.BottomRight)]
        public WatermarkPosition WatermarkPosition
        {
            get { return _enumWatermarkPosition; }
            set { _enumWatermarkPosition = value; }
        }

        [Description("��ȡ�������Ƿ��������ͼ"), DefaultValue(false)]
        public bool IsGenerateThumb
        {
            get { return _bIsGenerateThumb; }
            set { _bIsGenerateThumb = value; }
        }

        [Description("��ȡ����������ͼ�������"), DefaultValue(400)]
        public int ThumbMaxWidth
        {
            get { return _iThumbMaxWidth; }
            set { _iThumbMaxWidth = value; }
        }

        [Description("��ȡ����������ͼ�����߶�"), DefaultValue(300)]
        public int ThumbMaxHeight
        {
            get { return _iThumbMaxHeight; }
            set { _iThumbMaxHeight = value; }
        }

        [Description("��ȡ�������Ƿ�������"), DefaultValue(true)]
        public bool IsRename
        {
            get { return _bIsRename; }
            set { _bIsRename = value; }
        }

        [Description("��ȡ��������������ʽ"), DefaultValue(Rename.DateTime)]
        public Rename RenameType
        {
            get { return _enumRenameType; }
            set { _enumRenameType = value; }
        }

        [Description("��ȡ�������ϴ��ɹ������ʾ�ı�"), DefaultValue("�ɹ��ϴ�һ��ͼƬ��")]
        public string SuccessfulText
        {
            get { return _strSuccessfulText; }
            set { _strSuccessfulText = value; }
        }

        [Description("��ȡ�������Ƿ���������ϴ�"), DefaultValue(false)]
        public bool AllowMulti
        {
            get { return _bIsAllowMulti; }
            set { _bIsAllowMulti = value; }
        }
        #endregion

        #region �����¼�
        public static object uploadEvent = new object();
        public event EventHandler Upload
        {
            add
            {
                Events.AddHandler(uploadEvent, value);
            }
            remove
            {
                Events.RemoveHandler(uploadEvent, value);
            }
        }

        protected override bool OnBubbleEvent(object source, EventArgs args)
        {
            if (source is Button)
            {
                OnUpload(null);
                return true;
            }
            return base.OnBubbleEvent(source, args);
        }

        protected virtual void OnUpload(EventArgs args)
        {
            EventHandler uploadHandler = (EventHandler)Events[uploadEvent];
            if (uploadHandler != null)
                uploadHandler(this, null);
            else
                base.RaiseBubbleEvent(this, args);
        }

        public event EventHandler Uploaded;
        public virtual void OnUploaded(EventArgs e)
        {
            if (Uploaded != null)
            {
                Uploaded(this, e);
            }
        }

        void _btnSave_Click(object sender, EventArgs e)
        {
            SaveOriginalPic();
            if (!_bIsAllowMulti)
            {
                _btnSave.Enabled = false;
            }
            OnUploaded(e);
            _imgPreView.Src = _strPicSavedPath;
        }
        #endregion

        #region ���캯��
        public ImageUploader()
        {
        }
        #endregion

        #region ��д������
        protected override HtmlTextWriterTag TagKey
        {
            get
            {
                return HtmlTextWriterTag.Table;
            }
        }
        #endregion

        #region ��д�ķ���
        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            Page.RegisterRequiresPostBack(this);
            Page.ClientScript.GetPostBackClientHyperlink(this, "");
            if (!Page.ClientScript.IsClientScriptBlockRegistered(FILE_UPLOAD_SCRIPT_ID))
            {
                Page.ClientScript.RegisterClientScriptBlock(Type.GetType("System.String"), FILE_UPLOAD_SCRIPT_ID, FILE_UPLOAD_SCRIPT);
            }
        }

        protected override void CreateChildControls()
        {
            Controls.Clear();
            ClearChildViewState();
            CreateControlHierarchy();
            PrepareControlHierarchy();
            TrackViewState();
            ChildControlsCreated = true;
        }

        protected override void Render(HtmlTextWriter writer)
        {
            EnsureChildControls();
            base.Render(writer);
        }
        #endregion

        #region ˽�з���

        #region ���ƿؼ�
        protected virtual void CreateControlHierarchy()
        {
            _fileUpload = new FileUpload();
            _btnSave = new Button();
            _imgPreView = new HtmlImage();

            _fileUpload.ID = "fileUploadImage";
            _btnSave.ID = "btnSave";
            _imgPreView.ID = "imgPreview";

            //ΪͼƬѡ��ؼ����JS�¼�
            _fileUpload.Attributes.Add("OnChange", string.Format(FILE_UPLOAD_HOOK, this.ClientID + "_fileUploadImage", this.ClientID + "_imgPreview", "\"" + _strPreViewImageUrl + "\""));
            //Ӧ�ñ��水ť����ʽ
            _btnSave.Attributes.Add("class", _strButtonSaveCSSClass);
            _btnSave.Text = _strButtonSaveText;
            _btnSave.Click += new EventHandler(_btnSave_Click);

            //����Ԥ��ͼƬ��Ĭ��ͼƬ
            _imgPreView.Src = _strPreViewImageUrl;

            if (!_bIsShowPreView)//�������ʾԤ��ͼƬ
            {
                _imgPreView.Visible = false;
            }

            //Ӧ��Ԥ��ͼƬ����ʽ
            _imgPreView.Attributes.Add("class", _strPreViewCSSClass);

            ChildControlsCreated = true;
        }

        protected virtual void PrepareControlHierarchy()
        {
            switch (_enumPreViewPosition)
            {
                case PreViewPosition.Top:
                    TableRow rowPreview = new TableRow();
                    TableCell cellPreview = new TableCell();
                    cellPreview.ColumnSpan = 2;
                    cellPreview.Controls.Add(_imgPreView);
                    rowPreview.Cells.Add(cellPreview);
                    cellPreview.Dispose();//�ͷ���Դ
                    Controls.Add(rowPreview);
                    rowPreview.Dispose();//�ͷ���Դ

                    TableRow rowUpload = new TableRow();
                    TableCell cellUploadSelector = new TableCell();
                    cellUploadSelector.Controls.Add(_fileUpload);
                    rowUpload.Cells.Add(cellUploadSelector);
                    cellUploadSelector.Dispose();//�ͷ���Դ

                    TableCell cellSaveButton = new TableCell();
                    cellSaveButton.Controls.Add(_btnSave);
                    rowUpload.Cells.Add(cellSaveButton);
                    cellSaveButton.Dispose();//�ͷ���Դ
                    Controls.Add(rowUpload);

                    rowUpload.Dispose();//�ͷ���Դ
                    break;
                case PreViewPosition.Right:
                    TableRow rowUpload1 = new TableRow();
                    TableCell cellUploadSelector1 = new TableCell();
                    cellUploadSelector1.Controls.Add(_fileUpload);
                    rowUpload1.Cells.Add(cellUploadSelector1);
                    cellUploadSelector1.Dispose();//�ͷ���Դ

                    TableCell cellSaveButton1 = new TableCell();
                    cellSaveButton1.Controls.Add(_btnSave);
                    rowUpload1.Cells.Add(cellSaveButton1);
                    cellSaveButton1.Dispose();//�ͷ���Դ
                    Controls.Add(rowUpload1);

                    TableCell cellPreview1 = new TableCell();
                    cellPreview1.Controls.Add(_imgPreView);
                    rowUpload1.Cells.Add(cellPreview1);
                    cellPreview1.Dispose();//�ͷ���Դ
                    Controls.Add(rowUpload1);

                    rowUpload1.Dispose();//�ͷ���Դ
                    break;
                case PreViewPosition.Bottom:
                    TableRow rowUpload2 = new TableRow();
                    TableCell cellUploadSelector2 = new TableCell();
                    cellUploadSelector2.Controls.Add(_fileUpload);
                    rowUpload2.Cells.Add(cellUploadSelector2);
                    cellUploadSelector2.Dispose();//�ͷ���Դ

                    TableCell cellSaveButton2 = new TableCell();
                    cellSaveButton2.Controls.Add(_btnSave);
                    rowUpload2.Cells.Add(cellSaveButton2);
                    cellSaveButton2.Dispose();//�ͷ���Դ
                    Controls.Add(rowUpload2);

                    rowUpload2.Dispose();//�ͷ���Դ

                    TableRow rowPreview2 = new TableRow();
                    TableCell cellPreview2 = new TableCell();
                    cellPreview2.ColumnSpan = 2;
                    cellPreview2.Controls.Add(_imgPreView);
                    rowPreview2.Cells.Add(cellPreview2);
                    cellPreview2.Dispose();//�ͷ���Դ
                    Controls.Add(rowPreview2);
                    rowPreview2.Dispose();//�ͷ���Դ
                    break;
                case PreViewPosition.Left:
                    TableRow rowUpload3 = new TableRow();

                    TableCell cellPreview3 = new TableCell();
                    cellPreview3.Controls.Add(_imgPreView);
                    rowUpload3.Cells.Add(cellPreview3);
                    cellPreview3.Dispose();//�ͷ���Դ
                    Controls.Add(rowUpload3);

                    TableCell cellUploadSelector3 = new TableCell();
                    cellUploadSelector3.Controls.Add(_fileUpload);
                    rowUpload3.Cells.Add(cellUploadSelector3);
                    cellUploadSelector3.Dispose();//�ͷ���Դ

                    TableCell cellSaveButton3 = new TableCell();
                    cellSaveButton3.Controls.Add(_btnSave);
                    rowUpload3.Cells.Add(cellSaveButton3);
                    cellSaveButton3.Dispose();//�ͷ���Դ
                    Controls.Add(rowUpload3);

                    rowUpload3.Dispose();//�ͷ���Դ
                    break;
                default:
                    TableRow rowUpload4 = new TableRow();
                    TableCell cellUploadSelector4 = new TableCell();
                    cellUploadSelector4.Controls.Add(_fileUpload);
                    rowUpload4.Cells.Add(cellUploadSelector4);
                    cellUploadSelector4.Dispose();//�ͷ���Դ

                    TableCell cellSaveButton4 = new TableCell();
                    cellSaveButton4.Controls.Add(_btnSave);
                    rowUpload4.Cells.Add(cellSaveButton4);
                    cellSaveButton4.Dispose();//�ͷ���Դ
                    Controls.Add(rowUpload4);

                    TableCell cellPreview4 = new TableCell();
                    cellPreview4.Controls.Add(_imgPreView);
                    rowUpload4.Cells.Add(cellPreview4);
                    cellPreview4.Dispose();//�ͷ���Դ
                    Controls.Add(rowUpload4);

                    rowUpload4.Dispose();//�ͷ���Դ
                    break;
            }
        }
        #endregion

        #region �ϴ�ͼƬ

        /// <summary>
        /// ����ԭͼ
        /// </summary>
        private void SaveOriginalPic()
        {
            //ȡ���ϴ����ļ�
            System.Web.HttpPostedFile hpfImage = _fileUpload.PostedFile;

            string strPicName = hpfImage.FileName;
            string strPicNameWithExtend = strPicName.Substring(strPicName.LastIndexOf('\\') + 1);//ȡ������չ�����ļ���
            string strPicNameWithoutExtend = strPicNameWithExtend.Substring(0, strPicNameWithExtend.IndexOf('.'));//ȡû����չ�����ļ���
            string strExtendName = strPicNameWithExtend.Substring(strPicNameWithExtend.IndexOf('.')).ToLower();//ȡ��չ��

            if (!hpfImage.ContentType.ToUpper().StartsWith("IMAGE/"))//�������ͼƬ����
            {
                throw new Exception("���ϴ��Ĳ���ͼƬ�ļ���");
            }
            if (_strAllowType.ToLower().IndexOf(strExtendName) == -1)//����ϴ�ͼƬ����չ���������������
            {
                throw new Exception("���ϴ���ͼƬ��ʽδ������");
            }
            if ((hpfImage.ContentLength / 1024) > _iMaxSize)//��������˹涨��С
            {
                throw new Exception("���ϴ���ͼƬ��С���������ƣ�");
            }

            if (_bIsRename)//���������
            {
                if (_enumRenameType == Rename.DateTime)//������������
                {
                    DateTime dtRenameTime = DateTime.Now;
                    StringBuilder sbRenameString = new StringBuilder();
                    sbRenameString.Append(dtRenameTime.Year.ToString());
                    sbRenameString.Append(dtRenameTime.Month.ToString());
                    sbRenameString.Append(dtRenameTime.Day.ToString());
                    sbRenameString.Append(dtRenameTime.Hour.ToString());
                    sbRenameString.Append(dtRenameTime.Minute.ToString());
                    sbRenameString.Append(dtRenameTime.Second.ToString());
                    sbRenameString.Append(dtRenameTime.Millisecond.ToString());

                    strPicNameWithoutExtend = sbRenameString.ToString();
                    sbRenameString = null;
                }
                else//��Guid������
                {
                    strPicNameWithoutExtend = Guid.NewGuid().ToString();
                }
            }
            _strPicSavedName = strPicNameWithoutExtend + strExtendName;//ͼƬ����
            _strPicSavedPath = _strPicSavePath + _strPicSavedName;//ͼƬ·��

            string strDir = HttpContext.Current.Server.MapPath(_strPicSavePath);//ͼƬ�ı���Ŀ¼
            if (!Directory.Exists(strDir))//���Ŀ¼������
            {
                Directory.CreateDirectory(strDir);//����Ŀ¼
            }

            string strSavePath = HttpContext.Current.Server.MapPath(_strPicSavedPath);//ȡ��ͼƬ����ľ���λ��
            hpfImage.SaveAs(strSavePath);//����ͼƬ

            if (_enumWatermarkType != WatermarkType.None)//��Ӱ�Ȩ��Ϣ
            {
                AddWatermark(strSavePath);
            }

            if (_bIsGenerateThumb)
            {
                GetThumb(strSavePath, strPicNameWithoutExtend, strExtendName);
            }
        }

        /// <summary>
        /// ��Ӱ�Ȩ��Ϣ
        /// </summary>
        /// <param name="strOraginalPath"></param>
        public void AddWatermark(string strOraginalPath)
        {
            switch (_enumWatermarkType)
            {
                case WatermarkType.None://��������ˮӡ
                    break;
                case WatermarkType.Image://ͼƬˮӡ
                    AddImageWatermark(strOraginalPath);
                    break;
                case WatermarkType.Text://����ˮӡ
                    AddTextWatermark(strOraginalPath);
                    break;
                default:
                    break;
            }
        }

        public void AddImageWatermark(string strOraginalPath)
        {
            string strWatermarkImagePath = HttpContext.Current.Server.MapPath(_strWatermarkImage);
            if (!File.Exists(strWatermarkImagePath))//���ˮӡͼƬ������
            {
                return;
            }

            System.Drawing.Image imgOraginal = System.Drawing.Image.FromFile(strOraginalPath);
            int iOraginalWidth = imgOraginal.Width;
            int iOraginalHeight = imgOraginal.Height;
            System.Drawing.Bitmap bitOraginal = new System.Drawing.Bitmap(imgOraginal, iOraginalWidth, iOraginalHeight);
            imgOraginal.Dispose();

            System.Drawing.Graphics gOraginal = System.Drawing.Graphics.FromImage(bitOraginal);
            //System.Drawing.Rectangle rectTextField = new System.Drawing.Rectangle(10, 10, iWidth - 20, iHeight - 20);

            System.Drawing.Image imgWatermark = System.Drawing.Image.FromFile(strWatermarkImagePath);
            int iWatermarkWidth = imgWatermark.Width;
            int iWatermarkHeight = imgWatermark.Height;

            System.Drawing.Rectangle rect;

            int iHCenter = (iOraginalWidth - iWatermarkWidth) / 2;
            int iVCenter = (iOraginalHeight - iWatermarkHeight) / 2;
            int iHRight = (iOraginalWidth - iWatermarkWidth - 10);
            int iVBottom = (iOraginalHeight - iWatermarkHeight - 10);

            //ˮӡ��λ��
            switch (_enumWatermarkPosition)
            {
                case WatermarkPosition.TopLeft:
                    rect = new System.Drawing.Rectangle(10, 10, iWatermarkWidth, iWatermarkHeight);
                    break;
                case WatermarkPosition.TopCenter:
                    rect = new System.Drawing.Rectangle(iHCenter, 10, iWatermarkWidth, iWatermarkHeight);
                    break;
                case WatermarkPosition.TopRight:
                    rect = new System.Drawing.Rectangle(iHRight, 10, iWatermarkWidth, iWatermarkHeight);
                    break;
                case WatermarkPosition.MiddleLeft:
                    rect = new System.Drawing.Rectangle(10, iVCenter, iWatermarkWidth, iWatermarkHeight);
                    break;
                case WatermarkPosition.MiddleCenter:
                    rect = new System.Drawing.Rectangle(iHCenter, iVCenter, iWatermarkWidth, iWatermarkHeight);
                    break;
                case WatermarkPosition.MiddleRight:
                    rect = new System.Drawing.Rectangle(iHRight, iVCenter, iWatermarkWidth, iWatermarkHeight);
                    break;
                case WatermarkPosition.BottomLeft:
                    rect = new System.Drawing.Rectangle(10, iVBottom, iWatermarkWidth, iWatermarkHeight);
                    break;
                case WatermarkPosition.BottomCenter:
                    rect = new System.Drawing.Rectangle(iHCenter, iVBottom, iWatermarkWidth, iWatermarkHeight);
                    break;
                case WatermarkPosition.BottomRight:
                    rect = new System.Drawing.Rectangle(iHRight, iVBottom, iWatermarkWidth, iWatermarkHeight);
                    break;
                default:
                    rect = new System.Drawing.Rectangle(10, 10, iWatermarkWidth, iWatermarkHeight);
                    break;
            }
            gOraginal.DrawImage(imgWatermark, rect);

            bitOraginal.Save(strOraginalPath, System.Drawing.Imaging.ImageFormat.Jpeg);

            bitOraginal.Dispose();
            gOraginal.Dispose();
            imgWatermark.Dispose();
        }

        public void AddTextWatermark(string strOraginalPath)
        {
            if (string.IsNullOrEmpty(_strWatermarkText))//���ˮӡ����Ϊ��
            {
                return;
            }

            System.Drawing.Image imgOraginal = System.Drawing.Image.FromFile(strOraginalPath);
            int iWidth = imgOraginal.Width;
            int iHeight = imgOraginal.Height;
            System.Drawing.Bitmap bitOraginal = new System.Drawing.Bitmap(imgOraginal, iWidth, iHeight);
            imgOraginal.Dispose();

            System.Drawing.Graphics gOraginal = System.Drawing.Graphics.FromImage(bitOraginal);

            System.Drawing.Rectangle rectTextField = new System.Drawing.Rectangle(10, 10, iWidth - 20, iHeight - 20);
            System.Drawing.StringFormat sf = GetStringFormat();

            System.Drawing.SolidBrush brush = new System.Drawing.SolidBrush(System.Drawing.Color.FromArgb(_btWatermarkTransparency/*���ֵ�͸����*/, _fontWatermarkColor));
            gOraginal.DrawString(_strWatermarkText, _fontWatermarkFont, brush, rectTextField, sf);

            sf.Dispose();
            brush.Dispose();

            bitOraginal.Save(strOraginalPath, System.Drawing.Imaging.ImageFormat.Jpeg);

            gOraginal.Dispose();
            bitOraginal.Dispose();
        }

        /// <summary>
        /// ����ˮӡ����λ��
        /// </summary>
        /// <returns></returns>
        private System.Drawing.StringFormat GetStringFormat()
        {
            System.Drawing.StringFormat sf = new System.Drawing.StringFormat();
            switch (_enumWatermarkPosition)
            {
                case WatermarkPosition.TopLeft:
                    sf.Alignment = System.Drawing.StringAlignment.Near;
                    sf.LineAlignment = System.Drawing.StringAlignment.Near;
                    break;
                case WatermarkPosition.TopCenter:
                    sf.Alignment = System.Drawing.StringAlignment.Center;
                    sf.LineAlignment = System.Drawing.StringAlignment.Near;
                    break;
                case WatermarkPosition.TopRight:
                    sf.Alignment = System.Drawing.StringAlignment.Far;
                    sf.LineAlignment = System.Drawing.StringAlignment.Near;
                    break;
                case WatermarkPosition.MiddleLeft:
                    sf.Alignment = System.Drawing.StringAlignment.Near;
                    sf.LineAlignment = System.Drawing.StringAlignment.Center;
                    break;
                case WatermarkPosition.MiddleCenter:
                    sf.Alignment = System.Drawing.StringAlignment.Center;
                    sf.LineAlignment = System.Drawing.StringAlignment.Center;
                    break;
                case WatermarkPosition.MiddleRight:
                    sf.Alignment = System.Drawing.StringAlignment.Far;
                    sf.LineAlignment = System.Drawing.StringAlignment.Center;
                    break;
                case WatermarkPosition.BottomLeft:
                    sf.Alignment = System.Drawing.StringAlignment.Near;
                    sf.LineAlignment = System.Drawing.StringAlignment.Far;
                    break;
                case WatermarkPosition.BottomCenter:
                    sf.Alignment = System.Drawing.StringAlignment.Center;
                    sf.LineAlignment = System.Drawing.StringAlignment.Far;
                    break;
                case WatermarkPosition.BottomRight:
                    sf.Alignment = System.Drawing.StringAlignment.Far;
                    sf.LineAlignment = System.Drawing.StringAlignment.Far;
                    break;
                default:
                    sf.Alignment = System.Drawing.StringAlignment.Center;
                    sf.LineAlignment = System.Drawing.StringAlignment.Far;
                    break;
            }
            return sf;
        }

        /// <summary>
        /// ��������ͼ
        /// </summary>
        /// <param name="strOraginalPath"></param>
        public void GetThumb(string strOraginalPath, string strPicNameWithoutExtend, string strExtendName)
        {
            System.Drawing.Image imgOraginal = System.Drawing.Image.FromFile(strOraginalPath);
            int iOraginalWidth = imgOraginal.Width;
            int iOraginalHeight = imgOraginal.Height;

            int toWidth;
            int toHeight;

            //ԭͼ�Ŀ�߱�
            float fWbH = (float)iOraginalWidth / (float)iOraginalHeight;
            //ԭͼ�ĸ߿��
            float fHbW = (float)iOraginalHeight / (float)iOraginalWidth;

            //�����߱ȴ���4:3���������������������ͼ
            if (fWbH >= (4.0f / 3.0f))
            {
                if (_iThumbMaxWidth < iOraginalWidth)
                {
                    toWidth = _iThumbMaxWidth;
                    toHeight = (int)(toWidth * fHbW);
                }
                else//���ָ��������ͼ��ȴ���ԭͼ�Ŀ�ȣ�����������ͼ
                {
                    toWidth = iOraginalWidth;
                    toHeight = iOraginalHeight;
                }
            }
            else//�����߱�С��4:3���������߶�����������ͼ
            {
                if (_iThumbMaxWidth < iOraginalWidth)
                {
                    toHeight = _iThumbMaxHeight;
                    toWidth = (int)(toHeight * fWbH);
                }
                else//���ָ��������ͼ�߶�С��ԭͼ�Ŀ�ȣ�����������ͼ
                {
                    toWidth = iOraginalWidth;
                    toHeight = iOraginalHeight;
                }
            }

            System.Drawing.Image bitmap = new System.Drawing.Bitmap(toWidth, toHeight);
            System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(bitmap);

            //�趨����ͼ����������
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            g.Clear(System.Drawing.Color.Transparent);
            g.DrawImage(imgOraginal, new System.Drawing.Rectangle(0, 0, toWidth, toHeight), new System.Drawing.Rectangle(0, 0, iOraginalWidth, iOraginalHeight), System.Drawing.GraphicsUnit.Pixel);

            //����ͼ��ͼƬ����
            _strPicThumbSavedName = strPicNameWithoutExtend + "_thumb" + strExtendName;
            string thumbServerPath = HttpContext.Current.Server.MapPath(_strPicThumbSavePath);
            if (!Directory.Exists(thumbServerPath))
            {
                Directory.CreateDirectory(thumbServerPath);
            }
            try
            {
                bitmap.Save(thumbServerPath + _strPicThumbSavedName, System.Drawing.Imaging.ImageFormat.Jpeg);
                _strPicThumbSavedPath = _strPicThumbSavePath + _strPicThumbSavedName;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                imgOraginal.Dispose();
                bitmap.Dispose();
                g.Dispose();
            }
        }
        #endregion

        #endregion

        #region IDisposable ��Ա

        void IDisposable.Dispose()
        {
            _strAllowType = null;
            _strButtonSaveCSSClass = null;
            _strButtonSaveText = null;
            _strPicSavedName = null;
            _strPicSavedPath = null;
            _strPicSavePath = null;
            _strSuccessfulText = null;
            _strPicThumbSavedName = null;
            _strPicThumbSavedPath = null;
            _strPicThumbSavePath = null;
            _strWatermarkImage = null;
            _strWatermarkText = null;
            _fileUpload.Dispose();
            _btnSave.Dispose();
            _fontWatermarkFont.Dispose();
        }

        #endregion

        #region ��������
        ~ImageUploader()
        {
            Dispose();
        }
        #endregion

        #region IPostBackDataHandler ��Ա

        public bool LoadPostData(string postDataKey, NameValueCollection postCollection)
        {
            return true;
        }

        public void RaisePostDataChangedEvent()
        {

        }

        #endregion
    }
}
