#ifndef MAINWINDOW_H
#define MAINWINDOW_H

#include <QMainWindow>
#include <QGraphicsScene>
#include <mygraphicsscene.h>


QT_BEGIN_NAMESPACE
namespace Ui { class MainWindow; }
QT_END_NAMESPACE

class MainWindow : public QMainWindow
{
    Q_OBJECT

public:
    MainWindow(QWidget *parent = nullptr);
    ~MainWindow();
    MyGraphicsScene *scene;
    QPolygonF *polygon;
    QGraphicsScene *second_scene;
    QGraphicsScene *third_scene;
    QTimer *timer;
    QPair<double, double> *drw_now_pos;
    void redraw();
    void moveImg();
    QAction *Rigth, *Left, *Forward, *Backward;

protected:
    void keyPressEvent(QKeyEvent* event);
private:
    Ui::MainWindow *ui;
};
#endif // MAINWINDOW_H
