import React, {
  Dispatch,
  memo,
  SetStateAction,
  useEffect,
  useRef,
} from "react";
import { Task } from "../../../configs";
import { PopupPage } from "../index";
import IntervalPicker from "./interval";
import DueText from "./due";
import GameImage from "../../../gameImage";
import HideCheck from "./hide";

const InfoPage = ({
  task,
  setTask,
  setPage,
  autoFocus,
  showDue,
}: {
  task: Task;
  setTask: Dispatch<SetStateAction<Task>>;
  setPage: Dispatch<SetStateAction<PopupPage>>;
  autoFocus?: boolean;
  showDue?: boolean;
}) => {
  const descriptionRef = useRef<HTMLTextAreaElement>(null);

  useEffect(() => {
    if (autoFocus) {
      descriptionRef.current?.focus();
    }
  }, [autoFocus]);

  return (
    <div className="py-2 flex flex-col space-y-1">
      <div className="flex flex-row space-x-2">
        <GameImage
          name={task.icon}
          className="w-6 h-6 object-contain pointer-events-auto cursor-pointer"
          onClick={() => setPage("icon")}
        />

        <input
          value={task.name}
          onInput={({ currentTarget: { value } }) => {
            setTask((task) => ({ ...task, name: value }));
          }}
          className="font-bold flex-1"
          placeholder={task.icon}
        />
      </div>

      <textarea
        ref={descriptionRef}
        value={task.description || ""}
        onInput={({ currentTarget: { value } }) => {
          setTask((task) => ({ ...task, description: value }));
        }}
        className="text-sm text-gray-600 resize-none h-12"
        placeholder="Task description"
      />

      <IntervalPicker
        value={task.refreshTime}
        setValue={(value) => {
          setTask((task) => ({ ...task, refreshTime: value }));
        }}
      />

      {showDue && (
        <>
          <HideCheck task={task} setTask={setTask} />
          <DueText task={task} />
        </>
      )}
    </div>
  );
};

export default memo(InfoPage);
