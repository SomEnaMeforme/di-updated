# Dependency Injection Container

DI-контейнеры используется во многих команд Контура для управления зависимостями с соблюдением Dependency Inversion Principle.

Пройдя блок, ты научишься конфигурировать и использовать контейнер в типовых ситуациях, в частности в нетривиальных. А также поймешь, как контейнер использовать не нужно.

Все это на примере контейнера Ninject, но полученные знания будут применимы и к другим контейнерам с точностью до нюансов синтаксиса.


## Необходимые знания

Понадобится знание C#

Рекомендуется пройти блоки [SOLID](https://github.com/kontur-courses/solid-design) и [Тестирование](https://github.com/kontur-courses/testing)


## Самостоятельная подготовка

Посмотри видеолекцию про [DI-контейнеры](https://ulearn.me/Course/cs2/Probliematika_69a66629-787b-4ef6-932b-25bafe6a4467) (~1.5 часов)

Практику выполнять не нужно.


## Очная встреча

~ 4.5 часа


## Закрепление материала

1. Выполни задание [TagsCloudContainer](HomeExercise.md)

2. Спецзадание __Death Injection__  
   Найди в своем проекте интересные места, которые сильно расходятся с идеями из видеолекций. Либо наоборот иллюстрируют и дополняют эти   идеи. Обрати внимание на:
    - Нарушение явного управления зависимостями / Dependency Injection. Чем это было обосновано, какую выгоду получили?
    - Активное, нестандартное, хитрое использование DI-контейнера. Чему могли бы научиться на этом примере другие?
    - Проекты, в которых есть сборка сложного графа зависимостей, но DI-контейнера нет. Почему нет? Есть ли причины его не использовать?
