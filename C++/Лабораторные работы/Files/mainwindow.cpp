#include "mainwindow.h"
#include "./ui_mainwindow.h"

#include <QPushButton>
#include <QFileDialog>
#include <QMessageBox>

MainWindow::MainWindow(QWidget *parent)
    : QMainWindow(parent)
    , ui(new Ui::MainWindow)
{
    ui->setupUi(this);
    QPushButton::connect(ui->pushButton, &QPushButton::pressed, this, &MainWindow::choosefile);
}

MainWindow::~MainWindow()
{
    delete ui;
}

void MainWindow::choosefile(){
    QString fileName = QFileDialog::getOpenFileName(this,
        tr("Open Text file"), "", tr("Text Files (*.txt *.md *.org)"));
    QMessageBox msg_box;
    if (fileName.isNull() || fileName.isEmpty())
        return;
    else{
        QString str = "Исходный текст:<br> ";
        QFile file(fileName);
        if (!file.open(QIODevice::ReadOnly | QIODevice::Text))
                return;
        QTextStream in(&file);
        QString line;
        QString text;
        while (!in.atEnd()) {
            line = in.readLine();
            text += line + "\n ";
        }
        QChar chr = text[text.length() - 3];
        str += text.sliced(0, text.length() - 3);
        QString max_word = "";
        int max_how = 0;
        for (auto word: text.split(' ')){
            if (max_how < word.count(chr, Qt::CaseInsensitive)){
                max_how = word.count(chr, Qt::CaseInsensitive);
                max_word = word;
            }

        }
        str += tr("Символ: ") + chr + tr("<br>");
        str += tr("Слово с наиюольшим повторением данного символа: ") + max_word;
        str.replace("\n", "<br>");
        msg_box.setText(str);
    }
    msg_box.exec();
}
