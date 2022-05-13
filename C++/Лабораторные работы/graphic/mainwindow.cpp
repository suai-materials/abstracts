#include "mainwindow.h"
#include "./ui_mainwindow.h"
#include "QtMath"
#include <QKeyEvent>
#include <QTimer>
#include <mygraphicsscene.h>

MainWindow::MainWindow(QWidget *parent)
    : QMainWindow(parent)
    , ui(new Ui::MainWindow)
{
    ui->setupUi(this);

    // таймер здесь
    timer = new QTimer(this);
    connect(timer, &QTimer::timeout, this, &MainWindow::moveImg);
    scene = new MyGraphicsScene(this);
    QBrush qbrush(QColor::fromRgbF(0, 0, 0, 0));
    QPen pen(QColor::fromRgbF(1, 0, 0, 1));
    pen.setWidth(2);
    scene->addLine(0, 540, 1920, 540);
    scene->addLine(960, 0, 960, 1080);
    QPointF last_point(0, 220);
    QPointF point;
    for (double i = 0; i < 1920; i += 1.0){
        point = QPointF(i, 540 - cos(i / 100) + cos(i / 100) / sin(i / 100));
        scene->addLine(QLineF(last_point, point), pen);
        last_point = point;
    }
    ui->graphicsView->setScene(scene);
    // Flowers without moves
    second_scene = new QGraphicsScene(this);
    polygon = new QPolygonF();
    *polygon << QPointF(299, 251) << QPointF(322, 347) << QPointF(407, 347) << QPointF(430, 251) << QPointF(299, 251);
    second_scene->addPolygon(*polygon, QPen(QColor::fromRgb(248, 207, 255)), QBrush(QColor::fromRgb(248, 207, 255)));
    second_scene->addLine(QLine(307, 106, 356, 251));
    second_scene->addLine(QLine(454, 110, 384, 251));
    second_scene->addLine(QLine(375, 100, 365, 250));
    second_scene->addEllipse(QRectF(307 - 10, 106 - 10, 20, 20), QPen(QColor::fromRgb(255, 185, 185)), QBrush(QColor::fromRgb(255, 185, 185)));
    second_scene->addEllipse(QRectF(454 - 10, 110 - 10, 20, 20), QPen(QColor::fromRgb(255, 185, 185)), QBrush(QColor::fromRgb(255, 185, 185)));
    second_scene->addEllipse(QRectF(375 - 10, 100 - 10, 20, 20), QPen(QColor::fromRgb(255, 185, 185)), QBrush(QColor::fromRgb(255, 185, 185)));
    ui->graphicsView_2->setScene(second_scene);


    // Flowers with moves
    drw_now_pos = new QPair<double, double>(0, 0);
    third_scene = new QGraphicsScene(this);
    redraw();
    //ui->graphicsView_3->grabKeyboard();

}

void MainWindow::keyPressEvent(QKeyEvent* event){
    switch ( event->key() ) {
        case Qt::Key_W:
            if (drw_now_pos->second > 0){
                drw_now_pos->second -= 5;
                redraw();
            }
            break;
        case Qt::Key_S:
            if (drw_now_pos->second + 159 < 1000){
                drw_now_pos->second +=5;
                redraw();
            }
            break;
        case Qt::Key_D:
            if (drw_now_pos->first + 130 < 1000){
                drw_now_pos->first += 5;
                redraw();
            }
            break;
        case Qt::Key_A:
            if (drw_now_pos->first > 0){
                drw_now_pos->first -= 5;
                redraw();
            }
            break;
        case Qt::Key_E:
            timer->start(100);
            break;
        case Qt::Key_Escape:
            timer->stop();
            break;
        default:
            event->ignore();
            break;
        }
}

void MainWindow::moveImg(){
    drw_now_pos->first += 4;
    drw_now_pos->second += 4;
    redraw();
}

void MainWindow::redraw(){
    third_scene->clear();
    polygon = new QPolygonF();
    *polygon << QPointF(drw_now_pos->first, drw_now_pos->second + 159) << QPointF(drw_now_pos->first + 23, drw_now_pos->second + 255) << QPointF(drw_now_pos->first + 108, drw_now_pos->second + 255) << QPointF(drw_now_pos->first + 131, drw_now_pos->second + 158) << QPointF(drw_now_pos->first, drw_now_pos->second + 159);
    third_scene->addPolygon(*polygon, QPen(QColor::fromRgb(248, 207, 255)), QBrush(QColor::fromRgb(248, 207, 255)));
    third_scene->addLine(QLine(drw_now_pos->first + 9, drw_now_pos->second + 14, drw_now_pos->first + 58, drw_now_pos->second + 159));
    third_scene->addLine(QLine(drw_now_pos->first + 77, drw_now_pos->second + 8, drw_now_pos->first + 67, drw_now_pos->second + 159));
    third_scene->addLine(QLine(drw_now_pos->first + 156, drw_now_pos->second + 18, drw_now_pos->first + 86, drw_now_pos->second + 159));
    third_scene->addEllipse(QRectF(drw_now_pos->first + 1, drw_now_pos->second + 6, 16, 16), QPen(QColor::fromRgb(255, 185, 185)), QBrush(QColor::fromRgb(255, 185, 185)));
    third_scene->addEllipse(QRectF(drw_now_pos->first + 69, drw_now_pos->second, 16, 16), QPen(QColor::fromRgb(255, 185, 185)), QBrush(QColor::fromRgb(255, 185, 185)));
    third_scene->addEllipse(QRectF(drw_now_pos->first + 148, drw_now_pos->second + 10, 16, 16), QPen(QColor::fromRgb(255, 185, 185)), QBrush(QColor::fromRgb(255, 185, 185)));
    ui->graphicsView_3->setScene(third_scene);
}


MainWindow::~MainWindow()
{
    delete ui;
}

