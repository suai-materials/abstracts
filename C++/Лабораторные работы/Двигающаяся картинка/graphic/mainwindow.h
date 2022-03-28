#ifndef MAINWINDOW_H
#define MAINWINDOW_H

#include <QMainWindow>
#include <QGraphicsScene>


QT_BEGIN_NAMESPACE
namespace Ui { class MainWindow; }
QT_END_NAMESPACE

class MainWindow : public QMainWindow
{
    Q_OBJECT

public:
    MainWindow(QWidget *parent = nullptr);
    ~MainWindow();
    QGraphicsScene *scene;
    QPolygonF *polygon;
    QGraphicsScene *second_scene;
    QGraphicsScene *third_scene;
    QPair<double, double> *drw_now_pos;
    void redraw();
    QAction *Rigth, *Left, *Forward, *Backward;

protected:
    void keyPressEvent(QKeyEvent* event);
private:
    Ui::MainWindow *ui;
};
#endif // MAINWINDOW_H
