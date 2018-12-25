Namespace ReportInCode
    Partial Public Class Form1
        ''' <summary>
        ''' Required designer variable.
        ''' </summary>
        Private components As System.ComponentModel.IContainer = Nothing

        ''' <summary>
        ''' Clean up any resources being used.
        ''' </summary>
        ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso (components IsNot Nothing) Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        #Region "Windows Form Designer generated code"

        ''' <summary>
        ''' Required method for Designer support - do not modify
        ''' the contents of this method with the code editor.
        ''' </summary>
        Private Sub InitializeComponent()
            Me.btnReportCreate = New DevExpress.XtraEditors.SimpleButton()
            Me.SuspendLayout()
            ' 
            ' btnReportCreate
            ' 
            Me.btnReportCreate.Location = New System.Drawing.Point(61, 16)
            Me.btnReportCreate.Name = "btnReportCreate"
            Me.btnReportCreate.Size = New System.Drawing.Size(170, 23)
            Me.btnReportCreate.TabIndex = 0
            Me.btnReportCreate.Text = "Create and Edit the Report"
            ' 
            ' Form1
            ' 
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(292, 55)
            Me.Controls.Add(Me.btnReportCreate)
            Me.Name = "Form1"
            Me.Text = "How to construct an XtraSchedulerReport at runtime"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
            Me.ResumeLayout(False)

        End Sub

        #End Region

        Private WithEvents btnReportCreate As DevExpress.XtraEditors.SimpleButton
    End Class
End Namespace

