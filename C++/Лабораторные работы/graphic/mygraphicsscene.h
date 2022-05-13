#ifndef MYGRAPHICSSCENE_H
#define MYGRAPHICSSCENE_H

#include <QGraphicsScene>

class MyGraphicsScene : public QGraphicsScene
{
public:
    explicit MyGraphicsScene(QObject *parent = nullptr);
private:
    void mousePressEvent(QGraphicsSceneMouseEvent *event) override;
};

#endif // MYGRAPHICSSCENE_H
