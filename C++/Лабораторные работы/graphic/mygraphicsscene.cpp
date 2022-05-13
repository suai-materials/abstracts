#include "mygraphicsscene.h"

#include <QGraphicsSceneMouseEvent>
#include <qdebug.h>

MyGraphicsScene::MyGraphicsScene(QObject *parent)
    : QGraphicsScene{parent}
{

}

void MyGraphicsScene::mousePressEvent(QGraphicsSceneMouseEvent * e)
{
    QPair<double, double> *drw_now_pos = new QPair<double, double>(e->scenePos().x(), e->scenePos().y());
    QPolygonF* polygon = new QPolygonF();
    *polygon << QPointF(drw_now_pos->first, drw_now_pos->second + 159) << QPointF(drw_now_pos->first + 23, drw_now_pos->second + 255) << QPointF(drw_now_pos->first + 108, drw_now_pos->second + 255) << QPointF(drw_now_pos->first + 131, drw_now_pos->second + 158) << QPointF(drw_now_pos->first, drw_now_pos->second + 159);
    this->addPolygon(*polygon, QPen(QColor::fromRgb(248, 207, 255)), QBrush(QColor::fromRgb(248, 207, 255)));
    this->addLine(QLine(drw_now_pos->first + 9, drw_now_pos->second + 14, drw_now_pos->first + 58, drw_now_pos->second + 159));
    this->addLine(QLine(drw_now_pos->first + 77, drw_now_pos->second + 8, drw_now_pos->first + 67, drw_now_pos->second + 159));
    this->addLine(QLine(drw_now_pos->first + 156, drw_now_pos->second + 18, drw_now_pos->first + 86, drw_now_pos->second + 159));
    this->addEllipse(QRectF(drw_now_pos->first + 1, drw_now_pos->second + 6, 16, 16), QPen(QColor::fromRgb(255, 185, 185)), QBrush(QColor::fromRgb(255, 185, 185)));
    this->addEllipse(QRectF(drw_now_pos->first + 69, drw_now_pos->second, 16, 16), QPen(QColor::fromRgb(255, 185, 185)), QBrush(QColor::fromRgb(255, 185, 185)));
    this->addEllipse(QRectF(drw_now_pos->first + 148, drw_now_pos->second + 10, 16, 16), QPen(QColor::fromRgb(255, 185, 185)), QBrush(QColor::fromRgb(255, 185, 185)));
}
