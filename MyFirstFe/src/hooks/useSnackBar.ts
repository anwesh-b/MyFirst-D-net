import { useSnackbar } from "notistack";

function useMySnackBar() {
  const { enqueueSnackbar } = useSnackbar();
  const success = (text: string) => {
    enqueueSnackbar(text, { variant: "success" });
  }

  const error = (text: string) => {
    enqueueSnackbar(text, { variant: "error" });
  }

  return { success, error };
}

export default useMySnackBar;
