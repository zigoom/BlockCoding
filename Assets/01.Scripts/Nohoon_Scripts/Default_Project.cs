using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Default_Project
{
    public enum SceneNumber {LOGO_1 , LOGO_2 , TITLE , STATE ,SCENE_END }

    public enum BlockState{
        MOVE,
        TURN_LEFT,
        TURN_RIGHT,

        IF_START,
        IF_START_1,
        IF_START_2,
        IF_START_3,
        IF_START_4,
        IF_START_5,
        IF_START_6,
        IF_START_7,
        IF_START_8,
        IF_START_9,
        IF_WALL,
        IF_TRUE,
        IF_FALSE,
        IF_TURN_LEFT,
        IF_TURN_RIGHT,
        IF_MOVE,
        IF_END,

        FOR_START,
        FOR_START_1,
        FOR_START_2,
        FOR_START_3,
        FOR_START_4,
        FOR_START_5,
        FOR_START_6,
        FOR_START_7,
        FOR_START_8,
        FOR_START_9,
        FOR_CNT_1,
        FOR_CNT_2,
        FOR_CNT_3,
        FOR_CNT_4,
        FOR_CNT_5,
        FOR_CNT_6,
        FOR_CNT_7,
        FOR_CNT_8,
        FOR_CNT_9,
        FOR_MOVE_FORWARD,
        FOR_END,

        STATE_NULL,

        STATE_END
        }
}